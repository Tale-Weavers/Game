function IsMobile() {
    var userAgent = navigator.userAgent.toLowerCase();
    return userAgent.includes("iphone") || userAgent.includes("android") || userAgent.includes("ipad");
}

IsMobile().toString();
