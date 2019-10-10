using e_Office.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace e_Office.Controllers
{
    public class InwardEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        static string[] Scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveFile, DriveService.Scope.DriveMetadata, DriveService.Scope.DriveAppdata };
        static string ApplicationName = "e-Office";

        // GET: InwardEntries
        public ActionResult Index()
        {
            return View(db.InwardEntries.ToList());
        }

        // GET: InwardEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InwardEntry inwardEntry = db.InwardEntries.Find(id);
            if (inwardEntry == null)
            {
                return HttpNotFound();
            }
            return View(inwardEntry);
        }

        // GET: InwardEntries/Create
        public ActionResult Create()
        {
            var model = new InwardEntry();
            ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", model.SendToDept);
            var users = db.UserDetails.Select(s => new
            {
                UserDetailId = s.UserDetailId,
                FullName = s.FirstName + " " + s.LastName
            }).ToList();

            ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", model.SendToCC);
            ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", model.SendToUser);
            ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", model.Classification);
            return View(model);
        }



        // POST: InwardEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InwardEntry inwardEntry, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                UserCredential credential;
                string credPath1 = @"~\Documents\credentials.json";
                using (var stream =
                     new FileStream(Server.MapPath(credPath1), FileMode.Open, FileAccess.ReadWrite))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = Server.MapPath(@"~\Documents\token.json");
                    //credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes,"admin", CancellationToken.None, new FileDataStore("MyAppsToken"))
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "admin",
                        CancellationToken.None,
                        new FileDataStore(credPath, false)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                var fileName = Path.GetFileName(file.FileName);
                var exten = Path.GetExtension(file.FileName);
                var docPath = SaveToDrive(file);
                inwardEntry.DocumentLocation= docPath;
                inwardEntry.DocumentName = fileName;
                inwardEntry.CC = string.Join(",", inwardEntry.SendToCC);
                db.InwardEntries.Add(inwardEntry);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", inwardEntry.SendToDept);
            var users = db.UserDetails.Select(s => new
            {
                UserDetailId = s.UserDetailId,
                FullName = s.FirstName + " " + s.LastName
            }).ToList();

            ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToCC);
            ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToUser);
            ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", inwardEntry.Classification);
            return View(inwardEntry);
        }

        public string SaveToDrive(HttpPostedFileBase file1)
        {
            UserCredential credential;

            using (var stream =
                 new FileStream(Server.MapPath("~/Documents/credentials.json"), FileMode.Open, FileAccess.ReadWrite))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = Server.MapPath("~/Documents/token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "admin",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            string _parent = "1licsmd8Lz5OZ2ROE9wEcW1sw1IiY4uGi";
            Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
            body.Name = System.IO.Path.GetFileName(file1.FileName);
            body.Description = "Inward Entry Doc";
            body.MimeType = GetMimeType(file1.FileName);
            if (!string.IsNullOrEmpty(_parent))
            {
                body.Parents = new List<string>() { _parent };
            }


            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file1.FileName,
                Parents = new List<string>
                {
                    _parent
                }
            };

            // File's content.
            System.IO.BinaryReader b = new System.IO.BinaryReader(file1.InputStream);
            byte[] byteArray = b.ReadBytes(file1.ContentLength);
            System.IO.MemoryStream _stream = new System.IO.MemoryStream(byteArray);
            try
            {
                FilesResource.CreateMediaUpload request = service.Files.Create(body, _stream, GetMimeType(file1.FileName));
                request.Alt = FilesResource.CreateMediaUpload.AltEnum.Json;
                request.Fields = "id";

                request.Upload();
                var d = request.ResponseBody;
                return d.Id;
            }
            catch (Exception e)
            {
                return "";
            }

        }

        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }

            return mimeType;
        }

        #region StorageConfiguration
        [HttpGet]
        public string createDirectory()
        {
            UserCredential credential;
         
            using (var stream =
                new FileStream(Server.MapPath("~/Documents/credentials.json"), FileMode.Open, FileAccess.ReadWrite))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = Server.MapPath(@"~\Documents\token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "admin",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            string _parent = "AppFolder";
            // Create metaData for a new Directory
            Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
            body.Name = "eOffice";
            body.Description = "";
            body.MimeType = "application/vnd.google-apps.folder";
            //body.Parents =  new List<string>() { "root" };
            if (!string.IsNullOrEmpty(_parent))
            {
                body.Parents = new List<string>() { "root" };
            };
            //create parent folder for app
            //   public static DriveService serv2 = new DriveService();
            try
            {
                //Google.Apis.Drive.v3.FilesResource.ListRequest checkDirectory = _service.Files.List();
                FilesResource.CreateRequest request = service.Files.Create(body);
                Google.Apis.Drive.v3.Data.File NewDirectory = request.Execute();
                return NewDirectory.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
                return "";
            }

        }
        public static string createFolder(DriveService _service, string _title, string _parent, int id)
        {

            Google.Apis.Drive.v3.Data.File NewDirectory = null;

            // Create metaData for a new Directory
            Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
            body.Name = _title;
            body.Description = "";
            body.MimeType = "application/vnd.google-apps.folder";
            //body.Parents = "root";
            if (!string.IsNullOrEmpty(_parent))
            {
                body.Parents = new List<string>() { _parent };
            };

            //create parent folder for app
            try
            {
                FilesResource.CreateRequest request = _service.Files.Create(body);
                NewDirectory = request.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }


            return NewDirectory.Id;
        }
        #endregion
    
        // GET: InwardEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InwardEntry inwardEntry = db.InwardEntries.Find(id);

            ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", inwardEntry.SendToDept);
            var users = db.UserDetails.Select(s => new
                            {
                                UserDetailId = s.UserDetailId,
                                FullName = s.FirstName + " " + s.LastName
                            }).ToList();

            ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", inwardEntry.CC);
            ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToUser);
            ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", inwardEntry.Classification);
            if (inwardEntry == null)
            {
                return HttpNotFound();
            }
            return View(inwardEntry);
        }

        // POST: InwardEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InwardEntry inwardEntry, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                UserCredential credential;
                string credPath1 = @"~\Documents\credentials.json";
                using (var stream =
                     new FileStream(Server.MapPath(credPath1), FileMode.Open, FileAccess.ReadWrite))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = Server.MapPath(@"~\Documents\token.json");
                    //credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes,"admin", CancellationToken.None, new FileDataStore("MyAppsToken"))
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "admin",
                        CancellationToken.None,
                        new FileDataStore(credPath, false)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
                // Create Drive API service.
                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var exten = Path.GetExtension(file.FileName);
                    var docPath = SaveToDrive(file);
                    inwardEntry.DocumentLocation = docPath;
                    inwardEntry.DocumentName = fileName;
                }
              
                inwardEntry.CC = string.Join(",", inwardEntry.SendToCC);
                db.Entry(inwardEntry).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.SendToDept = new SelectList(db.DeptMasters, "DeptId", "DeptName", inwardEntry.SendToDept);
            var users = db.UserDetails.Select(s => new
            {
                UserDetailId = s.UserDetailId,
                FullName = s.FirstName + " " + s.LastName
            }).ToList();

            ViewBag.SendToCC = new SelectList(users, "UserDetailId", "FullName", inwardEntry.CC);
            ViewBag.SendToUser = new SelectList(users, "UserDetailId", "FullName", inwardEntry.SendToUser);
            ViewBag.Classification = new SelectList(db.ClassificationMasters, "ClassificationId", "ClassificationName", inwardEntry.Classification);

            return View(inwardEntry);
        }

        // GET: InwardEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InwardEntry inwardEntry = db.InwardEntries.Find(id);
            if (inwardEntry == null)
            {
                return HttpNotFound();
            }
            return View(inwardEntry);
        }

        // POST: InwardEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InwardEntry inwardEntry = db.InwardEntries.Find(id);
            db.InwardEntries.Remove(inwardEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
