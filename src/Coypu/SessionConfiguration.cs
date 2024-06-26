﻿using System;
using Coypu.Drivers.Selenium;

namespace Coypu
{
    /// <summary>
    /// Global configuration settings
    /// </summary>
    public class SessionConfiguration : Options
    {
        const string DEFAULT_APP_HOST = "localhost";
        const int DEFAULT_PORT = 80;

        private string appHost;

        /// <summary>
        /// New default configuration
        /// </summary>
        public SessionConfiguration()
        {
            AppHost = DEFAULT_APP_HOST;
            Port = DEFAULT_PORT;
            SSL = false;
            Browser = Drivers.Browser.Firefox;
            Driver = typeof(SeleniumWebDriver);
            Headless = true;
        }

        /// <summary>
        /// <para>Specifies the browser you would like to control</para>
        /// <para>Default: Firefox</para>
        /// </summary>
        public Drivers.Browser Browser { get; set; }

        /// <summary>
        /// <para>Specifies whether the browser should run in headless mode</para>
        /// <para>Default: true</para>
        /// </summary>
        public bool Headless { get; set; }

        /// <summary>
        /// <para>Specifies the driver you would like to use to control the browser</para>
        /// <para>Default: SeleniumWebDriver</para>
        /// </summary>
        public Type Driver { get; set; }


        /// <summary>
        /// <para>The host of the website you are testing, e.g. 'github.com'</para>
        /// <para>Default: localhost</para>
        /// </summary>
        public string AppHost
        {
            get => appHost;
            set
            {
                if (Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    var uri = new Uri(value);
                    SSL = uri.Scheme == "https";
                    UserInfo = uri.UserInfo;
                    value = uri.Host;
                }
                appHost = value?.TrimEnd('/');
            }
        }

        internal string UserInfo { get; set; }

        /// <summary>
        /// <para>The port of the website you are testing</para>
        /// <para>Default: 80</para>
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// <para>Whether to use the HTTPS protocol to connect to website you are testing</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool SSL { get; set; }

        /// <summary>
        /// <para>Specifies the proxy you would like to use</para>
        /// <para>Default: null</para>
        /// </summary>
        public DriverProxy Proxy { get; set; }

        /// <summary>
        /// Ignore Browser related certificate errors
        /// </summary>
        public bool AcceptInsecureCertificates { get; set; }
    }
}
