// Polyfill querySelectorAll
if (!document.querySelectorAll) {
    document.querySelectorAll = function (selectors) {
        var style = document.createElement('style'), elements = [], element;
        document.documentElement.firstChild.appendChild(style);
        document._qsa = [];

        style.styleSheet.cssText = selectors + '{x-qsa:expression(document._qsa && document._qsa.push(this))}';
        window.scrollBy(0, 0);
        style.parentNode.removeChild(style);

        while (document._qsa.length) {
            element = document._qsa.shift();
            element.style.removeAttribute('x-qsa');
            elements.push(element);
        }
        document._qsa = null;
        return elements;
    };
}

// Polyfill querySelector
if (!document.querySelector) {
    document.querySelector = function (selectors) {
        var elements = document.querySelectorAll(selectors);
        return (elements.length) ? elements[0] : null;
    };
}

/**
 * @license addEventListener polyfill 1.0 / Eirik Backer / MIT Licence
 * https://gist.github.com/2864711/946225eb3822c203e8d6218095d888aac5e1748e
 */
(function (window, document, listeners_prop_name) {
    if ((!window.addEventListener || !window.removeEventListener) && window.attachEvent && window.detachEvent) {
        /**
         * @param {*} value
         * @return {boolean}
         */
        var is_callable = function (value) {
            return typeof value === 'function';
        };
        /**
         * @param {!Window|HTMLDocument|Node} self
         * @param {EventListener|function(!Event):(boolean|undefined)} listener
         * @return {!function(Event)|undefined}
         */
        var listener_get = function (self, listener) {
            var listeners = listener[listeners_prop_name];
            if (listeners) {
                var lis;
                var i = listeners.length;
                while (i--) {
                    lis = listeners[i];
                    if (lis[0] === self) {
                        return lis[1];
                    }
                }
            }
        };
        /**
         * @param {!Window|HTMLDocument|Node} self
         * @param {EventListener|function(!Event):(boolean|undefined)} listener
         * @param {!function(Event)} callback
         * @return {!function(Event)}
         */
        var listener_set = function (self, listener, callback) {
            var listeners = listener[listeners_prop_name] || (listener[listeners_prop_name] = []);
            return listener_get(self, listener) || (listeners[listeners.length] = [self, callback], callback);
        };
        /**
         * @param {string} methodName
         */
        var docHijack = function (methodName) {
            var old = document[methodName];
            document[methodName] = function (v) {
                return addListen(old(v));
            };
        };
        /**
         * @this {!Window|HTMLDocument|Node}
         * @param {string} type
         * @param {EventListener|function(!Event):(boolean|undefined)} listener
         * @param {boolean=} useCapture
         */
        var addEvent = function (type, listener, useCapture) {
            if (is_callable(listener)) {
                var self = this;
                self.attachEvent(
                    'on' + type,
                    listener_set(self, listener, function (e) {
                        e = e || window.event;
                        e.preventDefault = e.preventDefault || function () { e.returnValue = false };
                        e.stopPropagation = e.stopPropagation || function () { e.cancelBubble = true };
                        e.target = e.target || e.srcElement || document.documentElement;
                        e.currentTarget = e.currentTarget || self;
                        e.timeStamp = e.timeStamp || (new Date()).getTime();
                        listener.call(self, e);
                    })
                );
            }
        };
        /**
         * @this {!Window|HTMLDocument|Node}
         * @param {string} type
         * @param {EventListener|function(!Event):(boolean|undefined)} listener
         * @param {boolean=} useCapture
         */
        var removeEvent = function (type, listener, useCapture) {
            if (is_callable(listener)) {
                var self = this;
                var lis = listener_get(self, listener);
                if (lis) {
                    self.detachEvent('on' + type, lis);
                }
            }
        };
        /**
         * @param {!Node|NodeList|Array} obj
         * @return {!Node|NodeList|Array}
         */
        var addListen = function (obj) {
			if(obj){
				var i = obj.length;
				if (i) {
					while (i--) {
						obj[i].addEventListener = addEvent;
						obj[i].removeEventListener = removeEvent;
					}
				} else {
					obj.addEventListener = addEvent;
					obj.removeEventListener = removeEvent;
				}
            }
            return obj;
        };

        addListen([document, window]);
        if ('Element' in window) {
            /**
             * IE8
             */
            var element = window.Element;
            element.prototype.addEventListener = addEvent;
            element.prototype.removeEventListener = removeEvent;
        } else {
            /**
             * IE < 8
             */
            //Make sure we also init at domReady
            document.attachEvent('onreadystatechange', function () { addListen(document.all) });
            docHijack('getElementsByTagName');
            docHijack('getElementById');
            docHijack('createElement');
            addListen(document.all);
        }
    }
})(window, document, 'x-ms-event-listeners');

// everis 2017 copyright
(function (window, undefined) {
    "use strict"

    // Block the following key combinations
    // -------------------------------------------------
    // F11                  ->  Fullscreen
    // F12                  ->  Developer tools
    // Alt + Enter          ->  Fullscreen (IE)
    // Ctrl + S             ->  Save As
    // Ctrl + U             ->  View page source
    // Ctrl + Shift + I     ->  Inspect element
    document.addEventListener('keydown', function (event) {
        var keyCode = event.keyCode || event.which;

        if (keyCode == 122 ||
            keyCode == 123 ||
            (event.altKey && keyCode == 13) ||
            (event.ctrlKey && keyCode == 83) ||
            (event.ctrlKey && keyCode == 85) ||
            (event.ctrlKey && event.shiftKey && keyCode == 73)) {

            event.preventDefault();
            event.stopPropagation();
            event.cancelBubble = false;

            return false;
        }
    }, false);

    // Block the Contextual Menu
    document.addEventListener('contextmenu', function (event) {
        event.preventDefault();
        event.stopPropagation();
    }, false);
    
    var intervalDocumentReady = setInterval(function () {
        if (document.readyState == 'complete') {
            clearInterval(intervalDocumentReady);

            var links = document.querySelectorAll('a[href]');

            for (var i = 0, j = links.length; i < j; i++) {
                var link = links[i];

                var href = link.getAttribute('href');
                console.log(href + ' - ' + href.substr(0, 11).toLowerCase());
                if (href.length > 0 && href.substr(0, 11).toLowerCase() != 'javascript:') {

                    link.setAttribute('href', 'javascript:void(0);');
                    link.setAttribute('data-href', href);

                    link.addEventListener('click', function (event) {
                        if (!event.ctrlKey && !event.shiftKey) {
                            window.location.href = event.target.getAttribute('data-href');
                        }
                    }, false);
                }
            }
        }
    }, 1);

    // Dectect Microsoft Internet Explorer
    function isIE() {
        var ua = window.navigator.userAgent;
        var msie = ua.indexOf("MSIE ");

        return (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))  // If Internet Explorer, return version number;
    }

    function guid() { // Public Domain/MIT
        var d = new Date().getTime();

        if (typeof performance !== 'undefined' && typeof performance.now === 'function') {
            d += performance.now(); //use high-precision timer if available
        }

        return 'xxxxxxxxxxxx4xxxyxxxxxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
    }

    var windowOpenNative = window.open;

    window.open = function (url, name, options) {
        var appWindow = windowOpenNative('about:blank', name, options);

        var form = document.createElement('form');

        form.setAttribute('action', url);
        form.setAttribute('method', 'POST');
        form.setAttribute('target', name);

        document.body.appendChild(form);

        form.submit();

        return appWindow;
    }
    var showModalDialogNative = window.showModalDialog;

    window.showModalDialog = function (url, name, options) {
        url = url.indexOf('?') != -1 ? url + '&__v__validated__=1' : url + '?__v__validated__=1';
        var appWindow = showModalDialogNative(url, name, options);
        return appWindow;
    }
    window.$__everisSecureApp__$ = function () {
        var currentWindow = window,
            width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : window.screen.width,
            height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : window.screen.height,
            left = (window.screen.width - width) / 2,
            top = (window.screen.height - height) / 2,
            options = 'toolbar=no,location=no,status=yes,resizable=yes,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left,
            url = window.location.href,
            formId = guid();

        window.moveTo(0, 0);
        window.resizeTo(0, 0);

        var appWindow = window.open(url, formId, options);
        
        if (!appWindow) {
            //alert('a popup was blocked. please make an exception for this site in your popup blocker and try again');
            alert('La ventana emergente esta bloqueada.\n\nPor Favor hacer una excepción para este sitio en su bloqueador de ventanas emergentes e intentarlo de nuevo.');
        } else {
            if (window.focus) {
                appWindow.focus();
            }

            var timeout = (isIE() ? 1 : 60000);

            var timeoutCloseParent = setTimeout(function () {
                currentWindow.location.replace('about:blank');

                try {
                    var parentWindow = appWindow.opener.open('about:blank', '_parent', '');
                    parentWindow.close();
                } catch (ex) {
                    alert(ex);
                }

                clearTimeout(timeoutCloseParent);
            }, timeout);
        }
    }
})(window, null);