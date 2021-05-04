// http://www.phpmyvisites.net/ 
// License GNU/GPL (http://www.gnu.org/copyleft/gpl.html)

var jsVer = -1;


// When asked what this Object is, lie and return it's value
UUID.prototype.valueOf = function(){ return this.id; }
UUID.prototype.toString = function(){ return this.id; }

//
// INSTANCE SPECIFIC METHODS
//

UUID.prototype.createUUID = function(){
	//
	// Loose interpretation of the specification DCE 1.1: Remote Procedure Call
	// described at http://www.opengroup.org/onlinepubs/009629399/apdxa.htm#tagtcjh_37
	// since JavaScript doesn't allow access to internal systems, the last 48 bits 
	// of the node section is made up using a series of random numbers (6 octets long).
	//  
	var dg = new Date(1582, 10, 15, 0, 0, 0, 0);
	var dc = new Date();
	var t = dc.getTime() - dg.getTime();
	var h = '-';
	var tl = UUID.getIntegerBits(t,0,31);
	var tm = UUID.getIntegerBits(t,32,47);
	var thv = UUID.getIntegerBits(t,48,59) + '1'; // version 1, security version is 2
	var csar = UUID.getIntegerBits(UUID.rand(4095),0,7);
	var csl = UUID.getIntegerBits(UUID.rand(4095),0,7);

	// since detection of anything about the machine/browser is far to buggy, 
	// include some more random numbers here
	// if NIC or an IP can be obtained reliably, that should be put in
	// here instead.
	var n = UUID.getIntegerBits(UUID.rand(8191),0,7) + 
			UUID.getIntegerBits(UUID.rand(8191),8,15) + 
			UUID.getIntegerBits(UUID.rand(8191),0,7) + 
			UUID.getIntegerBits(UUID.rand(8191),8,15) + 
			UUID.getIntegerBits(UUID.rand(8191),0,15); // this last number is two octets long
	return tl + h + tm + h + thv + h + csar + csl + h + n; 
}


//
// GENERAL METHODS (Not instance specific)
//


// Pull out only certain bits from a very large integer, used to get the time
// code information for the first part of a UUID. Will return zero's if there 
// aren't enough bits to shift where it needs to.
UUID.getIntegerBits = function(val,start,end){
	var base16 = UUID.returnBase(val,16);
	var quadArray = new Array();
	var quadString = '';
	var i = 0;
	for(i=0;i<base16.length;i++){
		quadArray.push(base16.substring(i,i+1));	
	}
	for(i=Math.floor(start/4);i<=Math.floor(end/4);i++){
		if(!quadArray[i] || quadArray[i] == '') quadString += '0';
		else quadString += quadArray[i];
	}
	return quadString;
}

// Numeric Base Conversion algorithm from irt.org
// In base 16: 0=0, 5=5, 10=A, 15=F
UUID.returnBase = function(number, base){
	//
	// Copyright 1996-2006 irt.org, All Rights Reserved.	
	//
	// Downloaded from: http://www.irt.org/script/146.htm	
	// modified to work in this class by Erik Giberti
	var convert = ['0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'];
    if (number < base) var output = convert[number];
    else {
        var MSD = '' + Math.floor(number / base);
        var LSD = number - MSD*base;
        if (MSD >= base) var output = this.returnBase(MSD,base) + convert[LSD];
        else var output = convert[MSD] + convert[LSD];
    }
    return output;
}

// pick a random number within a range of numbers
// int b rand(int a); where 0 <= b <= a
UUID.rand = function(max){
	return Math.floor(Math.random() * max);
}


function UUID(){
	this.id = this.createUUID();
}

 var visitorId = readCookie('synthasiteVisitorId');
 if (visitorId == null) {
 	var uuid = new UUID();
 	
 	createCookie('synthasiteVisitorId',uuid,365);
 	visitorId = readCookie('synthasiteVisitorId');
 	
 }

var visitId = readCookie('synthasiteVisitId');
 if (visitId == null) {
 	var uuid = new UUID();
 	
 	createCookie('synthasiteVisitId',uuid,0);
 	visitId = readCookie('synthasiteVisitId');
 	
 }


function createCookie(name,value,days) {
	var date = new Date();
	if (days) {
		
		date.setTime(date.getTime()+(days*24*60*60*1000));
		
	}
	else {
		date.setTime(date.getTime()+(15*60*1000));
	}
	var expires = "; expires="+date.toGMTString();
	document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) {
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
}

function getBrowser(obj) {
    var b=new Array("unknown", "unknown", "unknown", "unknown");

    (isEmpty(obj) ? brs=navigator.userAgent.toLowerCase() : brs=obj);

    if (brs.search(/omniweb[\/\s]v?(\d+([\.-]\d)*)/) != -1) {
    // Omniweb
        b[0]="omniweb";
        b[1]=brs.match(/omniweb[\/\s]v?(\d+([\.-]\d)*)/)[1];
        (b[1] > 4.5 ? b[2]="khtml" : b[2]="omniweb");
        (brs.search(/omniweb[\/\s]((\d+([\.-]\d)*)-)?v(\d+([\.-]\d)*)/) == -1 ?       b[3]=brs.match(/omniweb[\/\s](\d+([\.-]\d)*)/)[1] :        b[3]=brs.match(/omniweb[\/\s]((\d+([\.-]\d)*)-)?v(\d+([\.-]\d)*)/)[4]);
        return b;
    } else if (brs.search(/opera[\/\s](\d+(\.?\d)*)/) != -1) {
    // Opera
        b[0]="opera";
        b[1]=brs.match(/opera[\/\s](\d+(\.?\d)*)/)[1];
        b[2]="opera";
        b[3]=b[1];
        return b;
    } else if (brs.search(/crazy\s?browser\s(\d+(\.?\d)*)/) != -1) {
    // Crazy Browser
        b[0]="crazy";
        b[1]=brs.match(/crazy\s?browser\s(\d+(\.?\d)*)/)[1];
        b[2]="msie";
        b[3]=getMSIEVersion();
        return b;
    } else if (brs.search(/myie2/) != -1) {
    // MyIE2
        b[0]="myie2";
        b[2]="msie";
        b[3]=brs.match(/msie\s(\d+(\.?\d)*)/)[1];
        return b;
    } else if (brs.search(/netcaptor/) != -1) {
    // NetCaptor
        b[0]="netcaptor";
        b[1]=brs.match(/netcaptor\s(\d+(\.?\d)*)/)[1];
        b[2]="msie";
        b[3]=getMSIEVersion();
        return b;
    } else if (brs.search(/avant\sbrowser/) != -1) {
    // Avant Browser
        b[0]="avantbrowser";
        b[2]="msie";
        b[3]=getMSIEVersion();
        return b;
    } else if (brs.search(/msn\s(\d+(\.?\d)*)/) != -1) {
    // MSN Explorer
        b[0]="msn";
        b[1]=brs.match(/msn\s(\d+(\.?\d)*)/)[1];
        b[2]="msie";
        b[3]=getMSIEVersion();
        return b;
    } else if (brs.search(/msie\s(\d+(\.?\d)*)/) != -1) {
    // MS Internet Explorer
        b[0]="msie";
        b[1]=getMSIEVersion();
        b[2]="msie";
        b[3]=b[1];
        return b;
    } else if (brs.search(/powermarks\/(\d+(\.?\d)*)/) != -1) {
    // PowerMarks
        b[0]="powermarks";
        b[1]=brs.match(/powermarks\/(\d+(\.?\d)*)/)[1];
        b[2]="msie";
        try {
            b[3]=getMSIEVersion();
        } catch (e) { }
        return b;
} else if (brs.search(/konqueror[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Konqueror
        b[0]="konqueror";
        b[1]=brs.match(/konqueror[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="khtml";
        return b;
    } else if (brs.search(/safari\/(\d)*/) != -1) {
    // Safari
        b[0]="safari";
        b[1]=brs.match(/safari\/(\d+(\.?\d*)*)/)[1];
        b[2]="khtml";
        b[3]=brs.match(/applewebkit\/(\d+(\.?\d*)*)/)[1];
        return b;
    } else if(brs.search(/zyborg/) != -1) {
    // Zyborg (SSD)
        b[0]="zyborg";
        b[1]=brs.match(/zyborg\/(\d+(\.?\d)*)/)[1];
        b[2]="robot";
        b[3]="-1"
        return b;
    } else if (brs.search(/netscape6[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Netscape 6.x
        b[0]="netscape";
        b[1]=brs.match(/netscape6[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/netscape\/(7\.\d*)/) != -1) {
    // Netscape 7.x
        b[0]="netscape";
        b[1]=brs.match(/netscape\/(7\.\d*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/galeon[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Galeon
        b[0]="galeon";
        b[1]=brs.match(/galeon[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/nautilus[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Nautilus
        b[0]="nautilus";
        b[1]=brs.match(/nautilus[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/firefox[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Firefox
        b[0]="firefox";
        b[1]=brs.match(/firefox[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/k-meleon[\/\s](\d+([\.-]\d)*)/) != -1) {
    // K-Meleon
        b[0]="kmeleon";
        b[1]=brs.match(/k-meleon[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/playstation\s3/) != -1) {
    // Playstation 3
        b[0]="netfront";
        b[1]="2.81"; // Taken from the Wikipedia article
        b[2]="playstation3"
        b[3]=brs.match(/playstation\s3;\s(\d+\.\d+)/)[1];
        return b;
    } else if (brs.search(/firebird[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Firebird
        b[0]="firebird";
        b[1]=brs.match(/firebird[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/phoenix[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Phoenix
        b[0]="phoenix";
        b[1]=brs.match(/phoenix[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/camino[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Camino
        b[0]="camino";
        b[1]=brs.match(/camino[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/epiphany[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Epiphany
        b[0]="epiphany";
        b[1]=brs.match(/epiphany[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/chimera[\/\s](\d+([\.-]\d)*)/) != -1) {
    // Chimera
        b[0]="chimera";
        b[1]=brs.match(/chimera[\/\s](\d+([\.-]\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/icab[\s\/]?(\d+(\.?\d)*)/) !=-1) {
    // iCab
        b[0]="icab";
        b[1]=brs.match(/icab[\s\/]?(\d+(\.?\d)*)/)[1];
        b[2]="icab";
        b[3]=b[1];
        return b;
    } else if (brs.search(/netfront\/(\d+([\._]\d)*)/) != -1) {
    // NetFront
        b[0]="netfront";
        b[1]=brs.match(/netfront\/(\d+([\._]\d)*)/)[1];
        b[2]="netfront";
        b[3]=b[1];
        return b;
    } else if (brs.search(/netscape4\/(\d+([\.-]\d)*)/) != -1) {
    // Netscape 4.x
        b[0]="netscape";
        b[1]=brs.match(/netscape4\/(\d+([\.-]\d)*)/)[1];
        b[2]="mozold";
        b[3]=b[1];
        return b;
    } else if ( (brs.search(/mozilla\/(4.\d*)/) != -1) && (brs.search(/msie\s(\d+(\.?\d)*)/) == -1) ) {
        b[0]="netscape";
        b[1]=brs.match(/mozilla\/(4.\d*)/)[1];
        b[2]="mozold";
        b[3]=b[1];
        return b;
    } else if ((brs.search(/mozilla\/5.0/) != -1) && (brs.search(/gecko\//) != -1)) {
    // Mozilla Seamonkey
        b[0]="mozsea";
        b[1]=brs.match(/rv\x3a(\d+(\.?\d)*)/)[1];
        b[2]="gecko";
        b[3]=getGeckoVersion();
        return b;
    } else if (brs.search(/elinks/) != -1) {
    // ELinks
        b[0]="elinks";
        (brs.search(/elinks\/(\d+(\.?\d)*)/) == -1 ?
b[1]=brs.match(/elinks\s\x28(\d+(\.?\d)*)/)[1] :
b[1]=brs.match(/elinks\/(\d+(\.?\d)*)/)[1]);
        b[2]="elinks";
        b[3]=b[1];
        return b;
    } else if (brs.search(/w3m\/(\d+(\.?\d)*)/) != -1) {
    // w3m
        b[0]="w3m"
        b[1]=brs.match(/(^w3m|\sw3m)\/(\d+(\.?\d)*)/)[2];
        b[2]="w3m";
        b[3]=b[1];
        return b;
    } else if (brs.search(/links/) != -1) {
    // Links
        b[0]="links";
        (brs.search(/links\/(\d+(\.?\d)*)/) == -1 ? b[1]=brs.match(/links\s\x28(\d+(\.?\d)*)/)[1] : b[1]=brs.match(/links\/(\d+(\.?\d)*)/)[1]);
        b[2]="links";
        b[3]=b[1];
        return b;
    } else if (brs.search(/java[\/\s]?(\d+([\._]\d)*)/) != -1) {
    // Java (as web-browser)
        b[0]="java";
        b[1]=brs.match(/java[\/\s]?(\d+([\._]\d)*)/)[1];
        b[2]="java";
        b[3]=b[1];
        return b;
    } else if(brs.search(/lynx/) != -1) {
    // Lynx (SSD)
        b[0]="lynx";
        b[1]=brs.match(/lynx\/(\d+(\.?\d)*)/)[1];
        b[2]="libwww-fm";
        b[3]=brs.match(/libwww-fm\/(\d+(\.?\d)*)/)[1];
        return b;
    } else if(brs.search(/dillo/) != -1) {
    // Dillo (SSD)
        b[0]="dillo";
        b[1]=brs.match(/dillo\s*\/*(\d+(\.?\d)*)/)[1];
        b[2]="dillo";
        b[3]=b[1];
        return b;
    } else if(brs.search(/wget/) != -1) {
    // wget (SSD)
        b[0]="wget";
        b[1]=brs.match(/wget\/(\d+(\.?\d)*)/)[1];
        b[2]="robot";
        b[3]="-1"
        return b;
    } else if(brs.search(/googlebot\-image/) != -1) {
    // GoogleBot-Image (SSD)
        b[0]="googlebotimg";
        b[1]=brs.match(/googlebot\-image\/(\d+(\.?\d)*)/)[1];
        b[2]="robot";
        b[3]="-1"
        return b;
    } else if(brs.search(/googlebot/) != -1) {
    // GoogleBot (SSD)
        b[0]="googlebot";
        b[1]=brs.match(/googlebot\/(\d+(\.?\d)*)/)[1];
        b[2]="robot";
        b[3]="-1"
        return b;
    } else if(brs.search(/msnbot/) != -1) {
    // MSNBot (SSD)
        b[0]="msnbot";
        b[1]=brs.match(/msnbot\/(\d+(\.?\d)*)/)[1];
        b[2]="robot";
        b[3]="-1"
        return b;
    } else if(brs.search(/turnitinbot/) != -1) {
    // Turnitin (SSD)
        b[0]="turnitinbot";
        b[1]=brs.match(/turnitinbot\/(\d+(\.?\d)*)/)[1];
        b[2]="robot";
        b[3]="-1"
        return b;
    } else {
        b[0]="unknown";
        return b;
    }
}

// Return browser's (actual) major version or -1 if bad version entered
function getMajorVersion(v) {
    return (isEmpty(v) ? -1 : (hasDot(v) ? v : v.match(/(\d*)(\.\d*)*/)[1]))
}

// Return browser's (actual) minor version or -1 if bad version entered
function getMinorVersion(v) {
    return (!isEmpty(v) ? (!hasDot(v) ? v.match(/\.(\d*([-\.]\d*)*)/)[1] : 0) :
-1)
}

// Return operating system we are running on top of
function getOS(obj) {

    var os=new Array("unknown", "unknown");

    (isEmpty(obj) ? brs=navigator.userAgent.toLowerCase() : brs=obj);

    if (brs.search(/windows\sce/) != -1) {
        os[0]="wince";
        try {
            os[1]=brs.match(/windows\sce\/(\d+(\.?\d)*)/)[1];
        } catch (e) { }
        return os;
    } else if ( (brs.search(/windows/) !=-1) || ((brs.search(/win9\d{1}/) !=-1))
) {
        os[0]="win";
        if (brs.search(/nt\s5\.1/) != -1) {
            os[1]="xp";
        } else if (brs.search(/nt\s5\.0/) != -1) {
            os[1]="2000";
        } else if ( (brs.search(/win98/) != -1) || (brs.search(/windows\s98/)!=
-1 ) ) {
            os[1]="98";
        } else if (brs.search(/windows\sme/) != -1) {
            os[1]="me";
        } else if (brs.search(/nt\s5\.2/) != -1) {
            os[1]="win2k3";
        } else if ( (brs.search(/windows\s95/) != -1) || (brs.search(/win95/)!=
-1 ) ) {
            os[1]="95";
        } else if ( (brs.search(/nt\s4\.0/) != -1) || (brs.search(/nt4\.0/) ) !=
-1) {
            os[1]="nt4";
        }

        return os;
    } else if (brs.search(/linux/) !=-1) {
        os[0]="linux";
        try {
            os[1] = brs.match(/linux\s?(\d+(\.?\d)*)/)[1];
        } catch (e) { }
        return os;
    } else if (brs.search(/mac\sos\sx/) !=-1) {
        os[0]="macosx";
        return os;
    } else if (brs.search(/freebsd/) !=-1) {
        os[0]="freebsd";
        try {
            os[1] = brs.match(/freebsd\s(\d(\.\d)*)*/)[1];
        } catch (e) { }
        return os;
    } else if (brs.search(/sunos/) !=-1) {
        os[0]="sunos";
        try {
            os[1]=brs.match(/sunos\s(\d(\.\d)*)*/)[1];
        } catch (e) { }
        return os;
    } else if (brs.search(/irix/) !=-1) {
        os[0]="irix";
        try {
            os[1]=brs.match(/irix\s(\d(\.\d)*)*/)[1];
        } catch (e) { }
        return os;
    } else if (brs.search(/openbsd/) !=-1) {
        os[0]="openbsd";
        try {
            os[1] = brs.match(/openbsd\s(\d(\.\d)*)*/)[1];
        } catch (e) { }
        return os;
    } else if ( (brs.search(/macintosh/) !=-1) || (brs.search(/mac\x5fpowerpc/)
!= -1) ) {
        os[0]="macclassic";
        return os;
    } else if (brs.search(/os\/2/) !=-1) {
        os[0]="os2";
        try {
            os[1]=brs.match(/warp\s((\d(\.\d)*)*)/)[1];
        } catch (e) { }
        return os;
    } else if (brs.search(/openvms/) !=-1) {
        os[0]="openvms";
        try {
            os[1]=brs.match(/openvms\sv((\d(\.\d)*)*)/)[1];
        } catch (e)  { }
        return os;
    } else if ( (brs.search(/amigaos/) !=-1) || (brs.search(/amiga/) != -1) ) {
        os[0]="amigaos";
        try {
            os[1]=brs.match(/amigaos\s?(\d(\.\d)*)*/)[1];
        } catch (e) { }
        return os;
    } else if (brs.search(/hurd/) !=-1) {
        os[0]="hurd";
        return os;
    } else if (brs.search(/hp\-ux/) != -1) {
        os[0]="hpux";
        try {
            os[1]=brs.match(/hp\-ux\sb\.[\/\s]?(\d+([\._]\d)*)/)[1];
        } catch (e) { }
        return os;
    } else if ( (brs.search(/unix/) !=-1) || (brs.search(/x11/) != -1 ) ) {
        os[0]="unix";
        return os;
    } else if (brs.search(/cygwin/) !=-1) {
        os[0]="cygwin";
        return os;
    } else if (brs.search(/java[\/\s]?(\d+([\._]\d)*)/) != -1) {
        os[0]="java";
        try {
            os[1]=brs.match(/java[\/\s]?(\d+([\._]\d)*)/)[1];
        } catch (e) { }
        return os;
    } else if (brs.search(/palmos/) != -1) {
        os[0]="palmos";
        return os;
    } else if (brs.search(/symbian\s?os\/(\d+([\._]\d)*)/) != -1) {
        os[0]="symbian";
        try {
            os[1]=brs.match(/symbian\s?os\/(\d+([\._]\d)*)/)[1];
        } catch (e) { }
        return os;
    } else {
        os[0]="unknown";
        return os;
    }
}

// Return Gecko version
function getGeckoVersion() {
    return brs.match(/gecko\/([0-9]+)/)[1];
}

// Return MSIE version
function getMSIEVersion() {
    return brs.match(/msie\s(\d+(\.?\d)*)/)[1];
}

// Return full browser UA string
function getFullUAString(obj) {
    (isEmpty(obj) ? brs=navigator.userAgent.toLowerCase() : brs=obj);
    return brs;
}

// Is Flash plug-in installed?
function hasFlashPlugin(obj) {

    (isEmpty(obj) ? brs=navigator.userAgent.toLowerCase() : brs=obj);

    var f=new Array("0", "0");
    var brwEng=getBrowser(obj)[2];
    var opSys=getOS(obj)[0]; 

    //if (getBrowser(obj)[2]!="msie") {
    if ( (brwEng=="gecko") || (brwEng=="opera") || (brwEng=="khtml") || (brwEng=="mozold") || (opSys=="macosx") || (opSys=="macclassic") ) {
        // Non-IE Flash plug-in detection

        if (navigator.plugins && navigator.plugins.length) {
            x = navigator.plugins["Shockwave Flash"];
            if (x) {
                f[0] = 2;
                if (x.description) {
                    y = x.description;
                    f[1] = y.charAt(y.indexOf('.')-1);
                }
            } else {
                f[0] = 1;
            }
            if (navigator.plugins["Shockwave Flash 2.0"]) {
                f[0] = 2;
                f[0] = 2;
            }
        } else if (navigator.mimeTypes && navigator.mimeTypes.length) {
            x = navigator.mimeTypes['application/x-shockwave-flash'];
            if (x && x.enabledPlugin) {
                f[0] = 2;
            } else {
                f[0] = 1;
            }
        }

   return f;

  } else if (brwEng=="msie") {
      // IE flash detection.
       for(var i=15; i>0; i--) {
           try {
               var flash = new ActiveXObject("ShockwaveFlash.ShockwaveFlash." + i);
               f[1] = i;
               break;
               //return;
           } catch(e) { }
       }

       if (f[1]>0) {
           f[0]=2
       } else {
           f[0]=1
       }
   return f;
   } else {
       f[0]=0;
       f[1]=0;
       return f;
   }
}

// Are pop-up windows allowed for this site? (i. e. has the user a pop-up blocker?)
function popupsAllowed() {
    var allowed = false;
    var w = window.open("about:blank","","directories=no,height=1,width=1,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,left=0,top=0,location=no");
    if (w) {
        allowed = true;
        w.close();
    }
    return allowed;
}

// Helper function to detect Javascript version
function _jsVersion() {

    document.write('<script language="JavaScript1.0">');
    document.write('var jsVer=1.0;');
    document.write('</script>');

    document.write('<script language="JavaScript1.1">');
    document.write('var jsVer=1.1;');
    document.write('</script>');

    document.write('<script language="JavaScript1.2">');
    document.write('var jsVer=1.2;');
    document.write('</script>');

    document.write('<script language="JavaScript1.3">');
    document.write('var jsVer=1.3;');
    document.write('</script>');

    document.write('<script language="JavaScript1.4">');
    document.write('var jsVer=1.4;');
    document.write('</script>');

    document.write('<script language="JavaScript1.5">');
    document.write('var jsVer=1.5;');
    document.write('</script>');

    document.write('<script language="JavaScript1.6">');
    document.write('var jsVer=1.6;');
    document.write('</script>');

    document.write('<script language="JavaScript1.7">');
    document.write('var jsVer=1.7;');
    document.write('</script>');

    document.write('<script language="JavaScript1.8">');
    document.write('var jsVer=1.8;');
    document.write('</script>');

    document.write('<script language="JavaScript2.0">');
    document.write('var jsVer=2.0;');
    document.write('</script>');

}

// What is the newest version of Javascript does the browser report as supported?
function jsVersion() {
   _jsVersion(); 
   return jsVer;
}

/* FOR INTERNAL USE ONLY. THIS FUNCTIONS ARE SUBJECT TO CHANGE, DON'T TRUST THEM */
// Is input empty?
function isEmpty(input) {
    return (input==null || input =="")
}

// Does this string contain a dot?
function hasDot(input) {
    return (input.search(/\./) == -1)
}
/* END OF FOR INTERNAL USE ONLY FUNCTIONS */
function pmv_plugMoz(pmv_pl) {
	if (pmv_tm.indexOf(pmv_pl) != -1 && (navigator.mimeTypes[pmv_pl].enabledPlugin != null))
		return '1';
	return '0';
}
function pmv_plugIE(pmv_plug){
	pmv_find = false;
	document.write('<SCR' + 'IPT LANGUAGE=VBScript>\n on error resume next \n pmv_find = IsObject(CreateObject("' + pmv_plug + '")) </SCR' + 'IPT>\n');
	if (pmv_find) return '1';
	return '0';
}
document.write('<script src="jquery.js" type="text/javascript"></script>');
var pmv_jav='0'; if(navigator.javaEnabled()) pmv_jav='1';
var pmv_agent = navigator.userAgent.toLowerCase();
var pmv_moz = (navigator.appName.indexOf("Netscape") != -1);
var pmv_ie= (pmv_agent.indexOf("msie") != -1);
var pmv_win = ((pmv_agent.indexOf("win") != -1) || (pmv_agent.indexOf("32bit") != -1));
// Determine if cookie enabled
var pmv_cookie=(navigator.cookieEnabled)? '1' : '0';

//if not IE4+ nor NS6+
if ((typeof (navigator.cookieEnabled) =="undefined") && (pmv_cookie == '0')) { 
	document.cookie="pmv_testcookie"
	pmv_cookie=(document.cookie.indexOf("pmv_testcookie")!=-1)? '1' : '0';
}

var pmv_dir = '0'; 
var pmv_fla = '0'; 
var pmv_pdf = '0'; 
var pmv_qt = '0'; 
var pmv_rea = '0'; 
var pmv_wma = '0'; 

if (!pmv_win || pmv_moz){
	var pmv_tm = '';
	for (var i=0; i < navigator.mimeTypes.length; i++)
		pmv_tm += navigator.mimeTypes[i].type.toLowerCase();
	pmv_dir = pmv_plugMoz("application/x-director");
	pmv_fla = pmv_plugMoz("application/x-shockwave-flash");
	pmv_pdf = pmv_plugMoz("application/pdf");
	pmv_qt = pmv_plugMoz("video/quicktime");
	pmv_rea = pmv_plugMoz("audio/x-pn-realaudio-plugin");
	pmv_wma = pmv_plugMoz("application/x-mplayer2");
} else if (pmv_win && pmv_ie){
	pmv_dir = pmv_plugIE("SWCtl.SWCtl.1");
	pmv_fla = pmv_plugIE("ShockwaveFlash.ShockwaveFlash.1");
	if (pmv_plugIE("PDF.PdfCtrl.1") == '1' || pmv_plugIE('PDF.PdfCtrl.5') == '1' || pmv_plugIE('PDF.PdfCtrl.6') == '1') 
		pmv_pdf = '1';
	pmv_qt = pmv_plugIE("Quicktime.Quicktime"); // Old : "QuickTimeCheckObject.QuickTimeCheck.1"
	pmv_rea = pmv_plugIE("rmocx.RealPlayer G2 Control.1");
	pmv_wma = pmv_plugIE("wmplayer.ocx"); // Old : "MediaPlayer.MediaPlayer.1"

}
	
var pmv_do = document;
var pmv_rtu = '';
try {pmv_rtu = top.pmv_do.referrer;} catch(e) {
	if (parent) {
		if (parent.pmv_getReferer) {
			try {pmv_rtu = parent.pmv_getReferer;} catch(E3) {pmv_rtu = '';}
		}
		else  {
			try {pmv_rtu = parent.document.referrer;} catch(E) {
				try {pmv_rtu = document.referrer;} catch(E2) {pmv_rtu = '';}
			}
		}
		parent.pmv_getReferer = document.location.href;
	}
	else {
		try {pmv_rtu = document.referrer;} catch(E3) {pmv_rtu = '';}
	}
}

function getPageName(url) {
    var parts = url.split("/");
    var page = parts[parts.length-1];
    page.replace('.php','');
    if (page.length < 1) {
    	page = 'index';
    }
    return page;
}
// Get the url to call phpmyvisites
function pmv_getUrlStat(pmv_urlPmv, pmv_site, pmv_urlDoc, pmv_pname, pmv_typeClick, pmv_vars)
{
	var pmv_getvars='';
	if (pmv_vars) {
		for (var i in pmv_vars){
			if (!Array.prototype[i]){
				pmv_getvars = pmv_getvars + '&a_vars['+ escape(i) + ']' + "=" + escape(pmv_vars[i]);
			}
		}
	}
	var br=new Array(4);
	var os=new Array(2);
	
	br=getBrowser();
	os=getOS();
	jsver = jsVersion();
	var pmv_da = new Date();
	var utcdate = pmv_da.getUTCFullYear()+"-"+(pmv_da.getUTCMonth()+1)+"-"+pmv_da.getUTCDate()+" "+pmv_da.getUTCHours()+":"+pmv_da.getUTCMinutes()+":"+pmv_da.getUTCSeconds();
	var pmv_src = pmv_urlPmv;
	pmv_src += '?url='+escape(pmv_urlDoc)+'&pagename='+getPageName(pmv_urlDoc);
	pmv_src += '&browser='+br[0];
	pmv_src += '&browsermajorversion='+getMajorVersion(br[1]);
	pmv_src += '&browserminorversion='+getMinorVersion(br[1]);
	pmv_src += '&siteid='+pmv_site+'&resolution='+screen.width+'x'+screen.height+'&colorDepth='+screen.colorDepth;
	//pmv_src += '&datetime='+utcdate;
	pmv_src += '&flash='+pmv_fla+'&director='+pmv_dir+'&quicktime='+pmv_qt+'&realplayer='+pmv_rea;
	pmv_src += '&pdf='+pmv_pdf+'&windowsmedia='+pmv_wma+'&java='+pmv_jav;
	if ((pmv_typeClick) && (pmv_typeClick != "")) pmv_src += '&type='+escape(pmv_typeClick);
	pmv_src += '&sitereferer='+escape(pmv_rtu);
	
	
	//pmv_src += '&browser='+br[0];
	//pmv_src += '&browsermajorversion='+getMajorVersion(br[1]);
	//pmv_src += '&browserminorversion='+getMinorVersion(br[1]);
	pmv_src += '&engine='+br[2];
	pmv_src += '&engineversion='+br[3];
	pmv_src += '&os='+os[0];
	pmv_src += '&osversion='+os[1];
	pmv_src += '&javascriptversion='+jsver;
	pmv_src += '&visitorId='+visitorId;
	pmv_src += '&visitId='+visitId;
	return pmv_src;
}
// log action : pmv_typeClick = empty like a page, FILE ans in the futur RSS, PODCAST
function pmv_click (pmv_urlPmv, pmv_site, pmv_urlDoc, pmv_pname, pmv_typeClick, pmv_vars)
{
	var pmv_src = pmv_getUrlStat(pmv_urlPmv, pmv_site, pmv_urlDoc, pmv_pname, pmv_typeClick, pmv_vars);
	var pmv_img = new Image();
	pmv_img.src = pmv_src;
}
// Log current page
function pmv_log(pmv_urlPmv, pmv_site, pmv_pname, pmv_vars)
{
	var pmv_urlCur = pmv_do.location.href;
	var pmv_pos = pmv_urlCur.indexOf("//");
	if (pmv_pos > 0) {
		pmv_urlCur = pmv_urlCur.substr(pmv_pos);
	}
	var pmv_src = pmv_getUrlStat(pmv_urlPmv, pmv_site, pmv_urlCur, pmv_pname, "", pmv_vars);
	pmv_src = pmv_src + '&LoggingAgentReturnType=script';
	
	pmv_do.writeln('<script src="'+pmv_src+'"  type="text/javascript" >');
	pmv_do.writeln('</script>');
	

}

function Tracker() {
	// if (Math.floor(Math.random() * 5) == 1) {
	    pmv_log("http://tracking.synthasite.net/LoggingAgent/LoggingAgent", siteId, pmv_do.title, "");
    // }
}


