﻿angular.module('ngDownload', [])
    .factory('download', function ($http) {
        return {
            downloadFile : function (sUrl) { 
                     //iOS devices do not support downloading. We have to inform user about this. 
                     if (/(iP)/g.test(navigator.userAgent)) { 
                             alert('Your device does not support files downloading. Please try again in desktop browser.'); 
                             return false; 
                         } 
                 
 
                //If in Chrome or Safari - download via virtual link click 

                     if (navigator.userAgent.toLowerCase().indexOf('chrome') > -1 || navigator.userAgent.toLowerCase().indexOf('safari') > -1) {
                             //Creating new link node. 
                             var link = document.createElement('a'); 
                             link.href = sUrl; 
                     
 
                             if (link.download !== undefined) { 
                                     //Set HTML5 download attribute. This will prevent file from opening if supported. 
                                     var fileName = sUrl.substring(sUrl.lastIndexOf('/') + 1, sUrl.length); 
                                     link.download = fileName;
                                     console.log("fileName " + fileName);

                                 } 
                     
 
                             //Dispatching click event. 
                             if (document.createEvent) { 
                                   var e = document.createEvent('MouseEvents'); 
                                   e.initEvent('click', true, true); 
                                     link.dispatchEvent(e); 
                                     return true; 
                                 } 
                         } 
                 
 
                     // Force file download (whether supported by server). 
                     if (sUrl.indexOf('?') === -1) { 
                             sUrl += '?download'; 
                     }

                     console.log("sUrl" + sUrl);

                     window.open(sUrl, '_self'); 
                     return true; 
                 } 
        };
    });