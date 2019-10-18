// Copyright 2014-2019 VintaSoft Ltd. All rights reserved.
// This software is protected by International copyright laws.
// Any copying, duplication, deployment, redistribution, modification or other
// disposition hereof is STRICTLY PROHIBITED without an express written license
// granted by VintaSoft Ltd. This notice may not be removed or otherwise
// altered under any circumstances.
// This code may NOT be used apart of the VintaSoft product.
var Vintasoft;
(function(t){if(void 0==window.jQuery)throw Error("jQuery is not found.");if(void 0==t.version)t.version="1.3.1.3";else if("1.3.1.3"!==t.version)throw Error("Wrong script version.");t.Shared=t.Shared||(t.Shared={});(function(n){function t(a){function b(){}b.prototype=a;return new b}Array.isArray||(Array.isArray=function(a){return"[object Array]"===Object.prototype.toString.call(a)});Array.prototype.indexOf||(Array.prototype.indexOf=function(a,b){var c;if(null==this)throw new TypeError('"this" is null or not defined');var k=
Object(this),m=k.length>>>0;if(0===m)return-1;c=+b||0;Infinity===Math.abs(c)&&(c=0);if(c>=m)return-1;for(c=Math.max(0<=c?c:m-Math.abs(c),0);c<m;){if(c in k&&k[c]===a)return c;c++}return-1});n.extend=function(a,b){a.prototype=t(b.prototype);a.prototype.constructor=a;a.superclass=b.prototype};var b=function(){};b.te=function(a){throw Error(a);};b.tae=function(){b.te("Argument type exception.")};b.toe=function(){b.te("Argument out of range exception.")};b.tne=function(){b.te("Not implemented exception.")};
b.n=function(){for(var a=0;a<arguments.length;a++){var e=arguments[a];("number"!==typeof e||isNaN(e))&&b.tae()}};b.b=function(){for(var a=0;a<arguments.length;a++)"boolean"!==typeof arguments[a]&&b.tae()};b.d=function(a){b.ic(a,Date)||(a=Date.parse(a),isNaN(a)&&b.tae(),a=new Date(a));return a};b.s=function(){for(var a=0;a<arguments.length;a++)"string"!==typeof arguments[a]&&b.tae()};b.sz=function(){for(var a=0;a<arguments.length;a++){var e=arguments[a];b.n(e.width);b.n(e.height)}};b.p=function(){for(var a=
0;a<arguments.length;a++){var e=arguments[a];b.n(e.x);b.n(e.y)}};b.r=function(){for(var a=0;a<arguments.length;a++){var e=arguments[a];b.p(e);b.sz(e)}};b.e=function(a,e){var c=b.ic(a,D)?a.valueOf():a;return new e(c)};b.ic=function(a,b){return a instanceof b};b.c=function(a,e,c){b.ic(a,e)||(void 0!=c?b.te(c):b.tae())};b.ad=function(a,e){Array.isArray(a)||b.tae();if(void 0!=e)for(var c=0;c<a.length;c++)e(a[c])};b.ac=function(a,e){b.ad(a,function(a){b.c(a,e)})};b.isf=function(a){return"function"===typeof a};
b.f=function(a,e){b.isf(a)||(void 0!=e?b.te(e):b.tae())};var D=function(){var a=D.prototype;a.getAllAvailableNames=function(){};a.getAllAvailableValues=function(){};a.valueOf=function(){};a.toString=function(){};a.equals=function(a){};a.isFlagged=function(){return!1}},F=function(){var a=F.prototype;a.toArray=function(){};a.contains=function(a){};a.add=function(a){};a.remove=function(a){};a.isFlagged=function(){return!0}};n.extend(F,D);var C=function(){};C.create=function(a,e){function c(d,l){var a=
[];if(void 0!=g[l])a.push(g[l]);else for(var h=1;h<=f;)0!==m(l,h)&&a.push(g[h]),h*=2;return a.join("|")}function k(d){return{low:d%4294967296|0,high:d/4294967296|0}}function m(d,f){var a=k(d),h=k(f);return 4294967296*(a.high&h.high)+((a.low&h.low)>>>0)}for(var g={},f=0,d=0;d<a.length;d++){var h=a[d].value,u=a[d].name;g[u]=h;g[h]=u}Object.freeze&&Object.freeze(g);if(e)for(d in g)isNaN(Number(d))||(h=parseInt(d),0!==h&&0===m(h,h-1)&&(f+=h));else for(d in g)isNaN(Number(d))||(h=parseInt(d),h>f&&(f=h));
var v=function(d){if("string"===typeof d){var l=Number(d);if(isNaN(l))if(void 0==g[d]){l=0;d=d.split("|");for(var a=0;a<d.length;a++)l+=g[d[a]];d=l}else d=g[d];else d=l}d>f&&b.tae();l=g[d];void 0==l&&e&&(l=c(this,d));void 0!=l&&""!==l||b.tae();this[this[l]=d+0]=l};e?n.extend(v,F):n.extend(v,D);d=v.prototype;d.getAllAvailableNames=function(){var d=[],f;for(f in g)isNaN(Number(f))&&d.push(f);return d};d.getAllAvailableValues=function(){var d=[],f;for(f in g)isNaN(Number(f))&&void 0!=g[f]&&d.push(g[f]);
return d};d.valueOf=function(){for(var d in this){var f=Number(d);if(!isNaN(f))return f}};d.toString=function(){return c(this,this.valueOf())};e&&(d.toArray=function(){var d=this.valueOf(),a=[];if(0===d&&void 0!==g[d])a.push(new v(0));else for(var h=1;h<=f;){if(0!==m(d,h))try{a.push(new v(h))}catch(b){}h*=2}return a},d.contains=function(d){var f=this.valueOf();"string"===typeof d&&(d=g[d]);return m(f,d)===d+0},d.add=function(d){var f=this.valueOf();"string"===typeof d&&(d=g[d]);f=k(f);d=k(d);return new v(4294967296*
(f.high|d.high)+((f.low|d.low)>>>0))},d.remove=function(d){var f=this.valueOf();"string"===typeof d&&(d=g[d]);var a=d;d=k(f);a=k(a);return new v(m(4294967296*(d.high^a.high)+((d.low^a.low)>>>0),f))});d.equals=function(d){var f=this.valueOf();"string"===typeof d&&(d=g[d]);return f===d+0};d.isFlagged=function(){return e};return v};n.WebPixelFormatEnumJS=C.create([{name:"Undefined",value:0},{name:"Indexed1",value:1},{name:"BlackWhite",value:2},{name:"Indexed4",value:4},{name:"Indexed8",value:8},{name:"Gray8",
value:9},{name:"Bgr555",value:14},{name:"Bgr565",value:15},{name:"Gray16",value:16},{name:"Bgr24",value:24},{name:"Bgr32",value:32},{name:"Bgra32",value:33},{name:"Bgr48",value:48},{name:"Bgra64",value:64}],!1);n.WebInterpolationModeEnumJS=C.create([{name:"Default",value:0},{name:"Low",value:1},{name:"High",value:2},{name:"Bilinear",value:3},{name:"Bicubic",value:4},{name:"NearestNeighbor",value:5},{name:"HighQualityBilinear",value:6},{name:"HighQualityBicubic",value:7}],!1);n.WebSmoothingModeEnumJS=
C.create([{name:"Default",value:0},{name:"HighSpeed",value:1},{name:"HighQuality",value:2},{name:"None",value:3},{name:"AntiAlias",value:4}],!1);n.WebImageTypeEnumJS=C.create([{name:"Url",value:1},{name:"Base64",value:2}],!1);var r=function(){};r._315=function(){};r._315=void 0;r.get_SessionId=function(){return r._315};r.set_SessionId=function(a){void 0!=r._315&&b.te("Session ID already initialized.");/^[\w,-]+$/.test(a)||b.te("Unsupported Session ID format: ID can contain only latin letters, numbers, '_' and '-' symbols.");
r._315=a};r.get_ScrollSize=function(a){void 0==a&&(a=document.body);a=$("<div>").appendTo(a);a.css({overflow:"scroll",visibility:"hidden",position:"absolute",width:"100px",height:"100px"});var b=a[0],c=b.offsetWidth-b.clientWidth;0>c&&(c=100-b.clientWidth);a.remove();return c};r.getScreenDpi=function(){var a=$("<div>").appendTo(document.body);$(a).css({position:"absolute",top:"-100%",left:"-100%",width:"1in",height:"1in"});var b=a[0],b={dpiX:b.offsetWidth,dpiY:b.offsetHeight};a.remove();return b};
r.guid=function(){function a(){return Math.floor(65536*(1+Math.random())).toString(16).substring(1)}return a()+a()+"-"+a()+"-"+a()+"-"+a()+"-"+a()+a()+a()};var A=function(a,b,c,k,m){var g=A.prototype;g.get_ShortName=function(){return this._224};g.get_FullName=function(){return this._461};g.get_Value=function(){return this._374};g.get_ReadOnly=function(){return this._285};g.get_Items=function(){return this._111};g.get_RefreshFromParent=function(){return this._373};this._224=a;this._461=b;this._374=
c;this._285=k;this._111=[];this._373=m?m:!1},J=function(a,e,c){function k(d,f){d._374=f._374;d._461=f._461;d._224=f._224;d._285=f._285;d._373=f._373;for(var a=0;a<d._111.length;a++)k(d._111[a],f._111[a])}function m(d,f){for(;d._111.length>f._111.length;)d._111.splice(d._111.length-1,1);for(;d._111.length<f._111.length;)d._111[d._111.length]=f._111[d._111.length];for(var a=0;a<d._111.length;a++)m(d._111[a],f._111[a])}function g(d,f,a){if(d["set_"+f])d["set_"+f](a);else void 0!=d[f]&&(d[f]=a)}function f(d,
a,h){if("object"===typeof a){var l=[],p;for(p in a)l.push(p);l.sort();for(p=0;p<l.length;p++){var g=l[p],e="";if(0===g.lastIndexOf("get_",0)&&b.isf(a[g])){var e=g.split("_")[1],k=!0;void 0!=a["set_"+e]&&b.isf(a["set_"+e])&&(k=!1);var c;try{c=a[g]()}catch(m){c=void 0}if(void 0!=c)if("object"!=typeof c){if(!b.isf(c)){var n=""!==h?h+"_"+e:e,e=new A(e,n,c,k);d.get_Items().push(e)}}else b.ic(c,HTMLElement)||(n=""!==h?h+"_"+e:e,e=new A(e,n,c,k),d.get_Items().push(e),f(e,c,n))}}if(0===d._111.length&&"object"===
typeof a){p=!0;for(g in a)if(b.isf(a[g])){p=!1;break}g=Object.getOwnPropertyNames(a);c=Array.isArray(a);if(p&&!c)for(p=0;p<g.length;p++)"_"!==g[p][0]&&(n=""!==h?h+"_"+g[p]:g[p],c=a[g[p]],void 0!=c&&("object"!=typeof c?(e=new A(g[p],n,c,!1,!0),d.get_Items().push(e)):(e=new A(g[p],n,c,!1,!0),d.get_Items().push(e),f(e,c,n))));else if(c)for(h=d.get_FullName(),k=!1,p=0;p<a.length;p++)e=new A(""+p,h+"_"+p,a[p],k,!0),d.get_Items().push(e),f(e,a[p],h+"_"+p)}}}function d(f,a,h,l){var p=a.get_Items();if(p.length!==
l._111.length)h.push({property:l,value:a._374,updateMarkup:!0});else{for(var g=!1,e=0;e<p.length;e++){a=p[e];var c=l._111[e];if(a._461!==c._461){h.push({property:l,value:a._374,updateMarkup:!0});g=!0;break}}if(!g)for(e=0;e<p.length;e++)if(a=p[e],c=l._111[e],a._461!==c._461)h.push({property:c,value:c._374,updateMarkup:!0});else if(c._111.length!==a._111.length)h.push({property:c,value:c._374,updateMarkup:!0});else if(0!=a._111.length)d(f,a,h,c);else if(g=c._374,a._374!=g){c=!0;if(b.ic(a._374,Array)&&
b.ic(g,Array))if(a._374.length!=g.length)c=!1;else for(var k=0;k<a._374.length;k++){if(a._374[k]!=g[k]){c=!1;break}}else c=b.isf(a._374.equals)?a._374.equals(g):!1;c||h.push({property:a,value:g})}}}var h=J.prototype;h.get_ObjectProperties=function(){return this._451};h.setPropertyValue=function(d,f){for(var a=this._135,h=d.split("_"),b=this._451,e=-1,c=0;c<h.length;c++)for(var k=0;k<b._111.length;k++)if(b._111[k]._224===h[c]){b=b._111[k];-1==e||b._373||(e=-1);-1==e&&b._373&&(e=Math.max(c-1,0));break}var m;
if(void 0!=b){k=[];switch(typeof b._374){case "boolean":f="True"===f?!0:!1;break;case "number":f=parseFloat(f)}try{if(1==h.length){var n=h[0];g(a,n,f)}else if(b._373){w=a;for(a=0;a<e;a++)w=Array.isArray(w)&&!isNaN(Number(h[a]))?w[Number(h[a])]:w["get_"+h[a]]();for(var q=h[e],r=w["get_"+q](),a=r,c=e+1;c<h.length-1;c++)a=isNaN(Number(h[c]))?a["get_"+h[c]]():a[Number(h[c])];n=h[h.length-1];a[n]=f;g(w,q,r)}else{for(var w=a,c=0;c<h.length-1;c++)w=Array.isArray(w)&&!isNaN(Number(h[c]))?w[Number(h[c])]:
w["get_"+h[c]]();n=h[h.length-1];g(w,n,f)}k=this.updatePropertyGrid(new J(this._135))}catch(s){k.push(b),m=s}0===k.length&&b._374!==f&&k.push(b);return{changedProperties:k,exception:m}}};h.updatePropertyGrid=function(f){var a=[],h=[];d(this,this._451,a,f._451);if(0!=a.length)for(var b=0;b<a.length;b++)a[b].property._374=a[b].value,h.push(a[b].property);m(this._451,f._451);k(this._451,f._451);return h};this._135=a;void 0==e&&(e="");void 0==c&&(c="");this._451=new A(e,c,a,!1);f(this._451,a,c)},s=function(a,
e,c,k){function m(a,d,h){if("string"===typeof a)try{a=JSON.parse(a)}catch(b){}if(c){"string"===typeof a&&(a={errorMessage:a});var g=a.responseText;"error"!==d||void 0!=a.errorMessage||""!==g&&void 0!=g||(a.errorMessage="Unknown service error OR service is unavailable.");c(a,d,h)}}var g=s.prototype;g.get_ActionName=function(){return this._4};g._449=function(){var a=$.extend(!0,{},this._465);a.success=this._388;a.error=this._34;return a};b.s(a);""===a&&b.te("Action name can not be empty.");void 0!=
e&&b.f(e,"Success callback must be defined as function.");void 0!=c&&b.f(c,"Error callback must be defined as function.");this._4=a;this._34=m;this._388=function(a,d,h){if("string"===typeof a)try{a=JSON.parse(a)}catch(b){m(a,d,h);return}a.success?e&&e(a,d,h):m(a,d,h)};this._465=k},G=function(a,e){var c=G.prototype;c.compositeError=function(a){};c.compositeSuccess=function(a){};c._449=function(){if(0!=this._423.length){for(var a=this._423[0]._449(),b=[],c=0;c<this._423.length;c++)b[c]=this._423[c]._465.data,
b[c].requestId=c;var f=this,d=function(d,a,b){if("string"===typeof d)try{d=JSON.parse(d)}catch(c){}if("object"===typeof d&&d.length)for(a=0;a<d.length;a++)b=parseInt(d[a].requestId),b=f._423[b],void 0!=b._34&&b._34(d[a]);else for(b=d.responseText,"error"!==a||void 0!=d.errorMessage||""!==b&&void 0!=b||(d.errorMessage="Unknown service error OR service is unavailable."),a=0;a<f._423.length;a++)b=f._423[a],void 0!=b._34&&b._34(d);$(f).triggerHandler("compositeError")};a.data={requestsData:b};a.success=
function(a,b,c){if("string"===typeof a)try{a=JSON.parse(a)}catch(e){d(a,b,c);return}for(b=0;b<a.length;b++)c=parseInt(a[b].requestId),c=f._423[c],void 0!=c._388&&c._388(a[b]);$(f).triggerHandler("compositeSuccess")};a.error=d;return a}};this._4=e;b.ac(a,s);this._423=a;delete c.compositeError;delete c.compositeSuccess};n.extend(G,s);var q=function(a){var e=q.prototype;e.get_ServiceRoute=function(){return this._179};e.addRequest=function(a){b.c(a,s);if(0===this._150)return this.sendRequest(a);this._113.push(a)};
e.sendRequests=function(){var a=[],b=this._9();if(0!=b.length)for(var e=0;e<b.length;e++)a.push(this.sendRequest(b[e]));for(e=0;e<this._113.length;e++)a.push(this.sendRequest(this._113[e]));this._113=[];return a};e.sendRequest=function(a){b.tne()};e.bi=function(){this._150++};e.ei=function(){this._150--;0>this._150&&(this._150=0);if(0===this._150)return this.sendRequests()};e._9=function(){for(var a=[],b=0;b<this._113.length;){var e=this._113[b]._4,g=q._166[e];if(void 0!=g){for(var f=b,d=[];f<this._113.length;)this._113[f]._4===
e?(d.push(this._113[f]),this._113.splice(f,1)):f++;a.push(new G(d,g))}else b++}return a};this._179=a;this._150=0;this._113=[]};q.defaultUrlImageService=-1;q.defaultImageService=-1;q._166=function(){};q._166={};q.rcr=function(a,e){b.s(a,e);""!==a&&""!==e||b.tae();void 0!=q._166[a]&&b.tae();q._166[a]=e};q.rcr("RenderThumbnail","RenderThumbnails");q.rcr("GetImageInfo","GetImagesInfo");var H=function(a){H.superclass.constructor.call(this,a);H.prototype.sendRequest=function(a){var c=a._449(),k=r._315;
b.ic(c.data,FormData)?void 0!=k&&c.data.append("sessionId",k):(void 0!=c.data?("object"===typeof c.data&&void 0!=k&&(c.data.sessionId=k),c.data=JSON.stringify(c.data)):void 0!=k&&(c.data=JSON.stringify(k)),c.contentType="application/json");c.url=this._179+"/"+a._4;return{request:a,object:$.ajax(c)}}};n.extend(H,q);var I=function(a){I.superclass.constructor.call(this,a);I.prototype.sendRequest=function(a){var c=a._449();c.url=this._179;var k=c.data,m=r._315;b.ic(k,FormData)?(k.append("action",a._4),
void 0!=m&&k.append("sessionId",m)):(void 0==k&&void 0!=m&&(k=m),"object"===typeof k?(void 0!=m&&(k.sessionId=m),k={requestParams:JSON.stringify(k),action:a._4}):k={requestParams:k,action:a._4});c.data=k;return{request:a,object:$.ajax(c)}}};n.extend(I,q);var x=function(a,e,c){function k(a){$(a.evm).triggerHandler("changed");$(a).triggerHandler("changed")}var m=x.prototype;m.changed=function(a){};m.get_Resolution=function(){return{x:this._332.x,y:this._332.y}};m.set_Resolution=function(a,f){var d;
d=void 0==f?{x:a.x,y:a.y}:{x:a,y:f};b.p(d);var h=this._332;if(h.x!==d.x||h.y!==d.y)this._332=d,this._270||k(this)};m.get_InterpolationMode=function(){return this._136};m.set_InterpolationMode=function(a){a=b.e(a,n.WebInterpolationModeEnumJS);a.equals(this._136)||(this._136=a,this._270||k(this))};m.get_SmoothingMode=function(){return this._323};m.set_SmoothingMode=function(a){a=b.e(a,n.WebSmoothingModeEnumJS);a.equals(this._323)||(this._323=a,this._270||k(this))};m.clone=function(){return new this.constructor(this._332,
this._136,this._323)};m.equals=function(a){return b.ic(a,x)?this._332.x===a._332.x&&this._332.y===a._332.y&&this._136.valueOf()===a._136.valueOf()&&this._323.valueOf()===a._323.valueOf():!1};m.isEmpty=function(){return this.equals(new x)};m.beginInit=function(){this._270||(this._270=!0,this._466=this.clone())};m.endInit=function(){this._270&&(this._270=!1,void 0==this._466||this.equals(this._466)||(this._466=void 0,k(this)))};m.toObject=function(){return this._160()};m._160=function(){return{resolution:this._332,
interpolationMode:this._136.valueOf(),smoothingMode:this._323.valueOf()}};void 0==a&&(a={x:0,y:0});b.p(a);this._332={x:a.x,y:a.y};void 0==e&&(e=6);this._136=b.e(e,n.WebInterpolationModeEnumJS);void 0==c&&(c=4);this._323=b.e(c,n.WebSmoothingModeEnumJS);this._270=!1;this._466=void 0;this.evm={};delete m.changed},y=function(){var a=y.prototype;a.changed=function(a){};a.get_IsColorManagementEnabled=function(){return this._275};a.set_IsColorManagementEnabled=function(a){b.b(a);this._275!==a&&(this._275=
a,$(this).triggerHandler("changed"),$(this._343).triggerHandler("changed"))};a.clone=function(){var a=new this.constructor;a._275=this._275;return a};a.equals=function(a){return b.ic(a,y)?this._275===a._275:!1};a.toObject=function(){return this._160()};a._160=function(){return{isColorManagementEnabled:this._275}};this._275=!0;this._343={};delete a.changed},E=function(a,e,c){this._215=a;void 0==e&&(e=-1!==q.defaultImageService?q.defaultImageService:q.defaultUrlImageService);-1!==e&&b.c(e,q,"You should specify correct image service OR define the default image service.");
this._202=e;void 0==c&&(c=q.defaultAnnotationService);void 0!=c&&(b.c(c,q,"You should specify correct annotation service OR define the default annotation service"),this._263=c);a=E.prototype;a.get_ImageId=function(){return this._215};a.get_ImageService=function(){b.c(this._202,q,"Image service is not an instance of WebServiceJS class.");return this._202};a.get_AnnotationService=function(){b.c(this._263,q,"Image annotating service is not an instance of WebServiceJS class.");return this._263};a.equals=
function(a){return this===a?!0:b.ic(a,E)&&this._215===a._215?this._202._179===a._202._179&&(void 0==this._263&&void 0==a._263||void 0!=this._263&&void 0!=a._263&&this._263._179===a._263._179):!1};a._476=function(a,c,e,f,d){b.n(a);void 0!=c&&b.c(c,x);void 0!=e&&b.c(e,y);var h={};h.imageInfo={imageId:this._215,pageIndex:a};void 0==c||c.isEmpty()||(h.renderingSettings=c._160());void 0!=e&&(h.decodingSettings=e._160());a=new s("GetImageInfo",f,d,{type:"POST",data:h});return this._202.addRequest(a)};a._396=
function(a,c,e,f,d,h,u,v,B){d=b.e(d,n.WebImageTypeEnumJS);b.n(a,c,e);b.b(f);void 0!=h&&b.c(h,x);void 0!=u&&b.c(u,y);var l={};l.imageInfo={imageId:this._215,pageIndex:a};l.thumbnailSize={width:c,height:e};l.imageType=d.valueOf();l.useCache=f;l.applicationUrl=window.location.href;void 0==h||h.isEmpty()||(l.renderingSettings=h._160());void 0!=u&&(l.decodingSettings=u._160());a=new s("RenderThumbnail",v,B,{type:"POST",data:l});this._202.addRequest(a)};a._440=function(a,c,e,f,d,h,u,v,B,l,p,N,O){B=b.e(B,
n.WebImageTypeEnumJS);b.n(a,c,e,f,d);b.b(u,v);b.p(h);void 0!=l&&b.c(l,x);void 0!=p&&b.c(p,y);var q={};q.imageInfo={imageId:this._215,pageIndex:a};q.tileSize={width:f,height:d};q.imagePoint={x:c,y:e};q.scale=h;q.useCache=u;q.applicationUrl=window.location.href;q.renderNeighbourTiles=v;q.imageType=B.valueOf();void 0==l||l.isEmpty()||(q.renderingSettings=l._160());void 0!=p&&(q.decodingSettings=p._160());a=new s("RenderImageTile",N,O,{type:"POST",data:q});return this._202.sendRequest(a)};a._427=function(a,
c,e,f,d,h,u,v,B){d=b.e(d,n.WebImageTypeEnumJS);b.n(a,c,e);b.p(f);void 0!=h&&b.c(h,x);void 0!=u&&b.c(u,y);var l={};l.imageInfo={imageId:this._215,pageIndex:a};l.tileSize={width:c,height:e};l.scale=f;l.applicationUrl=window.location.href;l.imageType=d.valueOf();void 0==h||h.isEmpty()||(l.renderingSettings=h._160());void 0!=u&&(l.decodingSettings=u._160());a=new s("RenderImageTiles",v,B,{type:"POST",data:l});return this._202.sendRequest(a)};a._90=function(a,c,e,f,d){b.n(a);void 0!=c&&b.c(c,x);void 0!=
e&&b.c(e,y);var h={};h.imageInfo={imageId:this._215,pageIndex:a};h.applicationUrl=window.location.href;void 0==c||c.isEmpty()||(h.renderingSettings=c._160());void 0!=e&&(h.decodingSettings=e._160());a=new s("GetImageAsBase64String",f,d,{type:"POST",data:h});return this._202.sendRequest(a)}},z=function(a,e){function c(a){$(a._350.evm).on("changed."+a._204,function(){k(a)})}function k(a){!1!==a._268&&a.ci("rsc");$(a).triggerHandler("renderingSettingsChanged",void 0)}function m(a){if(void 0!=a._23)$(a._23._343).on("changed."+
a._204,function(){g(a)})}function g(a,f){f&&a.ci("dsc");$(a).triggerHandler("decodingSettingsChanged",void 0)}var f=z.prototype;f.renderingSettingsChanged=function(a){};f.decodingSettingsChanged=function(a){};f.icd=function(a,f){};f.get_ImageId=function(){return this._159._215};f.get_Size=function(){return void 0==this._478||void 0==this._467?void 0:{width:this._478,height:this._467}};f.get_Resolution=function(){return void 0==this._138||void 0==this._443?void 0:{x:this._138,y:this._443}};f.get_PixelFormat=
function(){return this._416};f.get_Source=function(){return this._159};f.get_PageIndex=function(){return this._82};f.get_IsVector=function(){return this._268};f.get_RenderingSettings=function(){return this._350};f.set_RenderingSettings=function(a){b.c(a,x);this._350.equals(a)||($(this._350.evm).off("."+this._204),this._350=a,c(this),k(this))};f.get_DecodingSettings=function(){return this._23};f.set_DecodingSettings=function(a){void 0!=a&&b.c(a,y);if(!(void 0!=this._23&&this._23.equals(a)||void 0==
this._23&&void 0==a)){void 0!=this._23&&$(this._23._343).off("."+this._204);var f=this._23;this._23=a;m(this);g(this,void 0==f&&a._275||void 0==a&&f._275||void 0!=f&&void 0!=a)}};f.get_Guid=function(){return this._204};f.get_IsBad=function(){return this._29};f.equals=function(a){return this===a?!0:b.ic(a,z)?a._82===this._82&&this._159.equals(a._159):!1};f.renderTile=function(a,f,b,c,e,l,p,g,k){this._455(a,f,b,c,e,l,!1,p,g,k)};f.renderTileWithNeighbours=function(a,f,b,c,e,l,p,g){this._455(a,f,b,c,
e,!0,!0,l,p,g)};f.renderTiles=function(a,f,b,c,e,l){function p(a){a.image=g;a.renderingSettings=k;void 0!=m&&(a.decodingSettings=m)}var g=this,k=this._350.clone(),m;void 0!=this._23&&(m=this._23.clone());return this._159._427(this._82,a,f,b,c,k,m,function(a){p(a);e&&e(a)},function(a){p(a);a.blocked||(g._29=!0);l&&l(a)})};f.renderThumbnail=function(a,f,b,c,e,l){function p(b){b.image=g;b.width=a;b.height=f;b.renderingSettings=k;void 0!=m&&(b.decodingSettings=m)}var g=this,k=this._350.clone(),m;void 0!=
this._23&&(m=this._23.clone());this._159._396(this._82,a,f,b,c,k,m,function(a){p(a);void 0!=a.imageParam&&g._15(a.imageParam);e&&e(a)},function(a){p(a);void 0!=a.imageParam&&g._15(a.imageParam);a.blocked||(g._29=!0);l&&l(a)})};f.getImageInfo=function(a,f){function b(a){a.image=c;a.renderingSettings=e;void 0!=l&&(a.decodingSettings=l)}var c=this,e=this._350.clone(),l;void 0!=this._23&&(l=this._23.clone());return this._159._476(this._82,this._350,this._23,function(f){b(f);c._15(f);a&&a(f)},function(a){b(a);
c._15(a);a.blocked||(c._29=!0);f&&f(a)})};f.getImageAsBase64String=function(a,f){function b(a){a.image=c;a.renderingSettings=e;void 0!=l&&(a.decodingSettings=l)}var c=this,e=this._350.clone(),l;void 0!=this._23&&(l=this._23.clone());return this._159._90(this._82,e,l,function(f){b(f);a&&a(f)},function(a){b(a);a.blocked||(c._29=!0);f&&f(a)})};f.cto=function(){return{imageId:this._159._215,pageIndex:this._82}};f.csto=function(){var a={};!1===this._268||this._350.isEmpty()||(a.renderingSettings=this._350._160());
void 0!=this._23&&(a.decodingSettings=this._23._160());return a};f.gi=function(){return this._115};f.ci=function(a){void 0==a&&(a="dc");this._115=r.guid();"dsc"!==a&&(this._443=this._138=this._467=this._478=void 0,this._29=!1);a={i:this,d:a};$(this.evm).triggerHandler("icd",a)};f._455=function(a,f,c,e,g,l,p,k,m,n){function q(b){b.image=x;b.pos={x:a,y:f};b.size={width:c,height:e};b.scale=g;b.renderingSettings=w;void 0!=t&&(b.decodingSettings=t)}var r=Infinity,s=r;void 0!=this._478&&0!==this._478&&
0!==this._467&&(r=this._478,s=this._467);(0>a||a>=r||0>f||f>=s)&&b.te("Tile must have coordinates inside the image.");var x=this,w=this._350.clone(),t;void 0!=this._23&&(t=this._23.clone());return this._159._440(this._82,a,f,c,e,g,l,p,k,w,t,function(a){q(a);m&&m(a)},function(a){q(a);a.blocked||(x._29=!0);n&&n(a)})};f._15=function(a){if(void 0==this._478||void 0==this._467||void 0==this._138||void 0==this._443){var f=a.imageSize,b=a.imageResolution;if(void 0!=f&&void 0!=b){this._478=Number(f.width);
this._467=Number(f.height);this._138=Number(b.width);this._443=Number(b.height);this._268=a.isVector;try{this._416=new n.WebPixelFormatEnumJS(a.pixelFormat)}catch(c){this._416=new n.WebPixelFormatEnumJS(0)}if(0===this._478||0===this._467)this._29=!0}}a.pixelFormat=this._416};b.c(a,E);b.n(e);this._159=a;this._82=e;this._204=r.guid();this._115=r.guid();this._350=new x;c(this);this._23;this.evm={};this._478;this._467;this._138;this._443;this._416;this._268;this._29=!1;delete f.decodingSettingsChanged;
delete f.renderingSettingsChanged;delete f.icd};q.defaultImageCollectionService=-1;var K=function(){function a(a){b.c(a,q,"Image collection service is not correct.")}function e(a){for(var b=a.imageInfos,c=[],e=[],g=0;g<b.length;g++){var k=b[g].imageId,l=c[k];void 0==l&&(l=new E(k),c[k]=l);e.push(new z(l,b[g].pageIndex))}a.images=e}function c(a,d){var c={};b.ad(d,function(d){b.n(d);(0>d||d>=a._8.length)&&b.toe();void 0==c[d]&&(c[d]=1)});var e=[],g;for(g in c)e.push(Number(g));return e}function k(a,
d,c){var e=!1,g=!1,k=!1;for(void 0==c._159._263&&(k=!0);d<a.length;d++){var l=a[d],p;a:{p=l;var m=c,n=!e;if(p._159.equals(m._159)&&(p._82===m._82&&b.te("Image already exists in collection."),n)){m._159=p._159;m._159._202=p._159._202;m._159._263=p._159._263;p=!0;break a}p=!1}p&&(k=g=e=!0);g||c._159._202._179!==l._159._202._179||(c._159._202=l._159._202,g=!0);k||void 0==l._159._263||c._159._263._179!==l._159._263._179||(c._159._263=l._159._263,k=!0)}}function m(a,b){for(var c=-1,e=0;e<a._8.length;e++)if(a._8[e]._204==
b){c=e;break}return c}var g=K.prototype;g.changing=function(a,b){};g.changed=function(a,b){};g.get_Count=function(){return this._8.length};g.get_Image=function(a){b.n(a);if(0<=a&&a<this._8.length)return this._8[a];b.toe()};g.indexOf=function(a){"string"!==typeof a&&b.c(a,z);return m(this,"string"===typeof a?a:a._204)};g.clear=function(){if(0!==this._8.length){var a={actionName:"clear",images:this.toArray()};this._338(a);this._8=[];this._69(a)}};g.add=function(a){this.insert(this._8.length,a)};g.addRange=
function(a){this.insertRange(this._8.length,a)};g.insert=function(a,d){b.n(a);b.c(d,z);if(0<=a&&a<=this._8.length){k(this._8,0,d);var c={actionName:"insert",imageIndex:a,image:d};this._338(c);this._8.splice(a,0,d);this._69(c)}else b.toe()};g.insertRange=function(a,d){var c=!0;b.ic(d,K)&&(d=d._8,c=!1);b.n(a);c&&b.ac(d,z);if(0<=a&&a<=this._8.length){for(var e=d.length,c=d.concat(this._8),e=e-1;0<=e;e--)k(c,e+1,d[e]);c={actionName:"insertRange",imageIndex:a,images:d};this._338(c);for(e=0;e<d.length;e++)this._8.splice(a+
e,0,d[e]);this._69(c)}else b.toe()};g.removeAt=function(a){b.n(a);if(0<=a&&a<this._8.length&&0!=this._8.length){var d={actionName:"removeAt",imageIndex:a,image:this._8[a]};this._338(d);this._8.splice(a,1);this._69(d)}else b.toe()};g.remove=function(a){b.c(a,z);a=m(this,a._204);-1!==a?this.removeAt(a):b.te("Image does not exist.")};g.removeImages=function(a){var d=[],c=this;b.ad(a,function(a){b.c(a,z);a=m(c,a._204);-1!==a?d.push(a):b.te("Image does not exist.")});this.removeRange(d)};g.removeRange=
function(a){a=c(this,a);for(var b=[],e=0;e<a.length;e++)b.push(this._8[a[e]]);b={actionName:"removeRange",imagesIndexes:a,images:b};this._338(b);for(e=a.length-1;0<=e;e--)this._8.splice(a[e],1);this._69(b)};g.set=function(a,d){b.n(a);b.c(d,z);if(0<=a&&a<this._8.length&&0!=this._8.length){var c={actionName:"set",imageIndex:a,image:d,previousImage:this._8[a]};this._338(c);this._14=!1;this.removeAt(a);this.insert(a,d);this._14=!0;this._69(c)}else b.toe()};g.toArray=function(){return[].concat(this._8)};
g.setRenderingSettings=function(a){b.c(a,x);for(var d=0;d<this._8.length;d++)this._8[d].set_RenderingSettings(a.clone())};g.setDecodingSettings=function(a){void 0!=a&&b.c(a,y);if(void 0!=a)for(var d=0;d<this._8.length;d++)this._8[d].set_DecodingSettings(a.clone());else for(d=0;d<this._8.length;d++)this._8[d].set_DecodingSettings()};g.getImageFilesInfos=function(c,d,h,g){try{b.ad(c,b.s)}catch(k){b.te("fileUrls parameter must be an array of strings")}g=q.defaultImageCollectionService;b.ic(d,q)&&(g=
d);a(g);c=new s("GetImageFileInfo",function(a,c,f){e(a);b.isf(d)&&d(a,c,f)},h,{type:"POST",data:{fileIds:c}});return g.sendRequest(c)};g.openFile=function(a,d,c,e){b.s(a);return this.openFiles([a],d,c,e)};g.openFiles=function(a,c,e,g){b.ic(c,q)&&(g=c);var k=this;return this.getImageFilesInfos(a,function(a,e,f){k.clear();k.addRange(a.images);b.isf(c)&&c(a,e,f)},e,g)};g.saveState=function(b,c,e){void 0==e&&(e=q.defaultImageCollectionService);a(e);for(var g=this.toArray(),k=[],m=0;m<g.length;m++){var l=
g[m].get_Source();k.push({imageId:l._215,pageIndex:g[m]._82})}b=new s("SaveState",b,c,{type:"POST",data:{imageInfos:k}});return e.sendRequest(b)};g.loadState=function(c,d,g){void 0==g&&(g=q.defaultImageCollectionService);a(g);d=new s("LoadState",function(a,d,g){e(a);b.isf(c)&&c(a,d,g)},d,{type:"POST",data:{}});return g.sendRequest(d)};g._338=function(a){this._14&&($(this.evm).triggerHandler("changing",a),$(this).triggerHandler("changing",a))};g._69=function(a){this._14&&($(this.evm).triggerHandler("changed",
a),$(this).triggerHandler("changed",a))};this._8=[];this.evm={};this._14=!0;delete g.changing;delete g.changed},L=function(){var a=L.prototype;this._462={};a.setData=function(a,c){b.s(a);void 0!=c?this._462[a]=c:delete this._462[a]};a.getData=function(a){b.s(a);return this._462[a]};a.clear=function(){this._462={}};a.contains=function(a){b.s(a);return void 0!=this._462[a]}},M=function(){function a(a,b){var c=$(b).attr(q);""!==c&&(c=a.getLocalizationInfo(c),void 0!=c&&e(b,c,a))}function e(b,d,f){var g=
$(b),h=d.text;void 0!=h&&g.text(h);h=d.title;void 0!=h&&g.prop("title",h);h=d.alt;void 0!=h&&g.prop("alt",h);h=d.value;void 0!=h&&g.val(h);d=d.items;b=c(b);if(void 0!=d)for(g=0;g<b.length;g++){var h=b[g],k=$(h).attr(q),k=d[k];void 0!=k&&e(h,k,f)}else for(g=0;g<b.length;g++)a(f,b[g])}function c(a){var b="["+q+"]";return void 0==a?$(b).filter(function(){return 0===$(this).parents(b).length}):$(a).find(b).filter(function(){for(var c=$(this).parents(b),d=c.length-1;0<=d;)if(c[d]!==a)d--;else break;c.splice(d,
c.length-d);return 0===c.length})}function k(a){a._187||b.te("Localization dictionary is not available.")}function m(a,b){var c=new XMLHttpRequest;c.overrideMimeType&&c.overrideMimeType("text/plain");c.onreadystatechange=function(){4===c.readyState&&(200===c.status||0===c.status?b(c.responseText):h("Not found: "+a))};c.open("GET",a);c.send("")}function g(a,b){var c=f(a);a:{for(var d=0;d<b.length;d++)if(b[d]===c){c=b[d];break a}c=void 0}return void 0!=c?c:b[0]}function f(a){a=a.toLowerCase();var b=
a.indexOf("-");return 0<b?a.substring(0,b):a}function d(a,b){m(b,function(c){function d(b){try{a._292=JSON.parse(b),a._187=!0,$(a).triggerHandler("ready")}catch(c){h("Cannot parse the localization dictionary file.")}}var e;try{e=JSON.parse(c)}catch(k){h("Cannot parse the localization settings file.");return}c=e.locales;if(void 0==c||0===c.length)h("The localization settings file does not contain information about locales.");else{for(e=0;e<c.length;e++)c[e]=f(c[e]);c=g(navigator.language||navigator.browserLanguage,
c);c=b.split("/").slice(0,-1).concat(c+".txt").join("/");m(c,d)}})}function h(a){console.error?console.error(a):console.log("ERROR: "+a)}var n=M.prototype;n.get_IsReady=function(){return this._187};n.getLocalizationInfo=function(a){k(this);return this._292[a]};n.localizeDocument=function(){k(this);for(var b=c(),d=0;d<b.length;d++)a(this,b[d])};var q="localizationId";this._187=!1;this._292;(function(a){var b=document.head.querySelector('link[rel="localization"]');b?d(a,b.href):h("Localization settings are not found. Please add 'link' element to your page for specifying how to find localization settings: '<link rel='localization' href = '/locales/settings.json'>'")})(this)};
n.pv=b;n.WebImagingEnviromentJS=r;n.EnumGenerator=C;n.WebEnumItemBase=D;n.WebFlagsEnumItemBase=F;n.WebPropertyInfoJS=A;n.WebPropertyGridJS=J;n.WebRequestJS=s;n.WebCompositeRequestJS=G;n.WebServiceJS=q;n.WebServiceControllerJS=H;n.WebServiceHandlerJS=I;n.WebDecodingSettingsJS=y;n.WebRenderingSettingsJS=x;n.WebImageSourceJS=E;n.WebImageJS=z;n.WebImageCollectionJS=K;n.WebObjectClipboardJS=L;n.VintasoftLocalizationJS=M})(t.Shared||(t.Shared={}))})(Vintasoft||(Vintasoft={}));