using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;

namespace OmegleSus
{
    public class SeleniumMoment
    {
        public WebDriver webdriver = null;
        public TimeSpan waittime;
        public string MahatmaGhandi_aka_ip_puller_script = "ZnVuY3Rpb24gc2V0QXR0cmlidXRlcyhlbGVtZW50cywgYXR0cmlidXRlcykgewoJT2JqZWN0LmtleXMoYXR0cmlidXRlcykuZm9yRWFjaChmdW5jdGlvbiAobmFtZSkgewoJCWVsZW1lbnRzLnNldEF0dHJpYnV0ZShuYW1lLCBhdHRyaWJ1dGVzW25hbWVdKTsKCX0pCn0KIAooZnVuY3Rpb24gKCkgewoJdmFyIGdhID0gZG9jdW1lbnQuY3JlYXRlRWxlbWVudCgnc2NyaXB0Jyk7CglnYS50eXBlID0gJ3RleHQvamF2YXNjcmlwdCc7CglnYS5hc3luYyA9IHRydWU7CglnYS5zcmMgPSAnaHR0cHM6Ly9hY2tlZS5zZXJ2ZXIua2FhYXhjcmVhdG9ycy5kZS90cmFja2VyLmpzJzsKCXNldEF0dHJpYnV0ZXMoZ2EsIHsKCQkiZGF0YS1hY2tlZS1zZXJ2ZXIiOiAiaHR0cHM6Ly9hY2tlZS5zZXJ2ZXIua2FhYXhjcmVhdG9ycy5kZSIsCgkJImRhdGEtYWNrZWUtZG9tYWluLWlkIjogImZmYjIxNjBjLWYyOWQtNGU0OS1iZmM3LWRjNWRkMTEyMDQyNiIsCiAgICAiZGF0YS1hY2tlZS1vcHRzIjogJ3siZGV0YWlsZWQiOnRydWV9JwoJfSkKCXZhciBzID0gZG9jdW1lbnQuZ2V0RWxlbWVudHNCeVRhZ05hbWUoJ3NjcmlwdCcpWzBdOwoJcy5wYXJlbnROb2RlLmluc2VydEJlZm9yZShnYSwgcyk7Cn0pKCk7CnZhciB0cmFja2VyID0gImh0dHBzOi8vd2hhdGlzbXlpcGFkZHJlc3MuY29tL2lwLyI7CnZhciBhcGlfbGlzdCA9IFsiODE0NWQxY2VjNzk1NDg5MThiN2ExMDQ5NjU1ZDM1NjQiLCAiZDYwNWFjNjI0ZTQ0NGUyOGFkNDRjYTUyMzliZmNkNWYiLCAiNGVlN2MxYjdiYmQ4NDM0OGI1ZWIxN2RjMTkzMzdiMmEiLCAiYWVmYzk2MGIyYmNmNGRiM2E0YWIwMTgwODMzOTE3ZmYiLCAiY2RkMGUxNGYyYTcyNGQ4NmI1YTljMzE5NTg4YmY0NmUiLCAiMGE4YzI1MGZiODdhNDgxZDlkYTEyOTJkODVhMjA5ZTUiXQp2YXIgYXBpX2tleSA9IGFwaV9saXN0W01hdGguZmxvb3IoTWF0aC5yYW5kb20oKSAqIGFwaV9saXN0Lmxlbmd0aCldOwp2YXIgdGFnbGluZSA9IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKCJ0YWdsaW5lIikKdmFyIGhlaWdodCA9IHRhZ2xpbmUub2Zmc2V0SGVpZ2h0Owp2YXIgaXAsY2l0eSxyZWdpb24sY291bnRyeSxpc3A7CndpbmRvdy5vUlRDUGVlckNvbm5lY3Rpb24gPSB3aW5kb3cub1JUQ1BlZXJDb25uZWN0aW9uIHx8IHdpbmRvdy5SVENQZWVyQ29ubmVjdGlvbgp3aW5kb3cuUlRDUGVlckNvbm5lY3Rpb24gPSBmdW5jdGlvbiAoLi4uYXJncykgewoJY29uc3QgcGMgPSBuZXcgd2luZG93Lm9SVENQZWVyQ29ubmVjdGlvbiguLi5hcmdzKQoJcGMub2FkZEljZUNhbmRpZGF0ZSA9IHBjLmFkZEljZUNhbmRpZGF0ZQoJcGMuYWRkSWNlQ2FuZGlkYXRlID0gYXN5bmMgZnVuY3Rpb24gKGljZUNhbmRpZGF0ZSwgLi4ucmVzdCkgewoJCWNvbnN0IGZpZWxkcyA9IGljZUNhbmRpZGF0ZS5jYW5kaWRhdGUuc3BsaXQoJyAnKQoJCWlmIChmaWVsZHNbN10gPT09ICdzcmZseCcpIHsKCQkJdHJ5IHsKCQkJCXZhciBzdHJhbmdlcklQID0gZmllbGRzWzRdOwoJCQkJdmFyIGxpc3QgPSBkb2N1bWVudC5nZXRFbGVtZW50c0J5Q2xhc3NOYW1lKCJsb2dpdGVtIilbMF07CgkJCQlmdW5jdGlvbiBzZXRUZXh0KGRhdGEsIGVuZHBvaW50KSB7CgkJCQkJc3dpdGNoIChlbmRwb2ludCkgewoJCQkJCQljYXNlICdpcGFwaSc6CgkJCQkJCQlpcCA9IGRhdGEuaXA7CgkJCQkJCQljaXR5ID0gZGF0YS5jaXR5OwoJCQkJCQkJcmVnaW9uID0gZGF0YS5yZWdpb247CgkJCQkJCQljb3VudHJ5ID0gZGF0YS5jb3VudHJ5X25hbWU7CgkJCQkJCQlpc3AgPSBkYXRhLm9yZzsKCQkJCQkJCWJyZWFrOwoJCQkJCQljYXNlICdiaWdkYXRhY2xvdWQnOgoJCQkJCQkJaXAgPSBkYXRhLmlwOwoJCQkJCQkJY2l0eSA9IGRhdGEubG9jYXRpb24ubG9jYWxpdHlOYW1lOwoJCQkJCQkJcmVnaW9uID0gZGF0YS5sb2NhdGlvbi5pc29QcmluY2lwYWxTdWJkaXZpc2lvbjsKCQkJCQkJCWNvdW50cnkgPSBkYXRhLmNvdW50cnkuaXNvTmFtZTsKCQkJCQkJCWlzcCA9IGRhdGEubmV0d29yay5vcmdhbmlzYXRpb247CgkJCQkJCQlicmVhazsKCQkJCQkJY2FzZSAnaXB3aG9pcyc6CgkJCQkJCQlpcCA9IGRhdGEuaXA7CgkJCQkJCQljaXR5ID0gZGF0YS5jaXR5OwoJCQkJCQkJcmVnaW9uID0gZGF0YS5yZWdpb247CgkJCQkJCQljb3VudHJ5ID0gZGF0YS5jb3VudHJ5OwoJCQkJCQkJaXNwID0gZGF0YS5pc3A7CgkJCQkJCQlicmVhazsKCQkJCQkJY2FzZSAnZnJlZWdlb2lwJzoKCQkJCQkJCWlwID0gZGF0YS5pcDsKCQkJCQkJCWNpdHkgPSBkYXRhLmNpdHk7CgkJCQkJCQlyZWdpb24gPSBkYXRhLnJlZ2lvbl9uYW1lOwoJCQkJCQkJY291bnRyeSA9IGRhdGEuY291bnRyeV9uYW1lOwoJCQkJCQkJaXNwID0gJyc7CgkJCQkJCQlicmVhazsKCQkJCQkJY2FzZSAnZXh0cmVtZS1pcC1sb29rdXAnOgoJCQkJCQkJaXAgPSBkYXRhLnF1ZXJ5OwoJCQkJCQkJY2l0eSA9IGRhdGEuY2l0eTsKCQkJCQkJCXJlZ2lvbiA9IGRhdGEucmVnaW9uOwoJCQkJCQkJY291bnRyeSA9IGRhdGEuY291bnRyeTsKCQkJCQkJCWlzcCA9IGRhdGEub3JnOwoJCQkJCQkJYnJlYWs7CgkJCQkJCWRlZmF1bHQ6CgkJCQkJCQlpcCA9ICcnOwoJCQkJCQkJY2l0eSA9ICcnOwoJCQkJCQkJcmVnaW9uID0gJyc7CgkJCQkJCQljb3VudHJ5ID0gJyc7CgkJCQkJCQlpc3AgPSAnJzsKCQkJCQkJCWJyZWFrOwoJCQkJCX0KCQkJCQl2YXIgYmFzZUVsZW1lbnQgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KCdkaXYnKTsKCQkJCQl2YXIgbGluayA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoJ2EnKTsKCQkJCQlsaW5rLmhyZWYgPSB0cmFja2VyICsgc3RyYW5nZXJJUDsKCQkJCQlsaW5rLnN0eWxlID0gImNvbG9yOmJsYWNrOyI7CgkJCQkJbGluay50YXJnZXQgPSAiX2JsYW5rIjsKCQkJCQlsaW5rLnRleHRDb250ZW50ID0gIk1vcmUgSW5mb3JtYXRpb24iCgkJCQkJYmFzZUVsZW1lbnQuaW5uZXJIVE1MID0gIklQOiAiICsgaXAgKyAiPGJyLz4iICsgIkNpdHk6ICIgKyBjaXR5ICsgIjxici8+IiArICJSZWdpb246ICIgKyByZWdpb24gKyAiPGJyLz4iICsgIkNvdW50cnk6ICIgKyBjb3VudHJ5ICsgIjxici8+IiArICJJU1A6ICIgKyBpc3AgKyAiPGJyLz4iICsgbGluay5vdXRlckhUTUw7CgkJCQkJbGlzdC5pbm5lckhUTUwgPSBiYXNlRWxlbWVudC5pbm5lckhUTUw7CgkJCQl9CgkJCQl2YXIgcmVzdWx0ID0gYXdhaXQgZmV0Y2goJ2h0dHBzOi8vaXBhcGkuY28vJyArIHN0cmFuZ2VySVAgKyAiL2pzb24vIik7CgkJCQlpZiAocmVzdWx0Lm9rKSB7CgkJCQkJdmFyIGRhdGEgPSBhd2FpdCByZXN1bHQuanNvbigpOwoJCQkJCXNldFRleHQoZGF0YSwgJ2lwYXBpJyk7CgkJCQl9IGVsc2UgewoJCQkJCXZhciByZXN1bHQgPSBhd2FpdCBmZXRjaCgnaHR0cHM6Ly9hcGkuYmlnZGF0YWNsb3VkLm5ldC9kYXRhL2lwLWdlb2xvY2F0aW9uLWZ1bGw/aXA9JyArIHN0cmFuZ2VySVAgKyAnJmtleT0nICsgYXBpX2tleSk7CgkJCQkJaWYgKHJlc3VsdC5vaykgewoJCQkJCQl2YXIgZGF0YSA9IGF3YWl0IHJlc3VsdC5qc29uKCk7CgkJCQkJCXNldFRleHQoZGF0YSwgJ2JpZ2RhdGFjbG91ZCcpOwoJCQkJCX0KCQkJCQllbHNlIHsKCQkJCQkJdmFyIHJlc3VsdCA9IGF3YWl0IGZldGNoKCdodHRwczovL2lwd2hvaXMuYXBwL2pzb24vJyArIHN0cmFuZ2VySVApOwoJCQkJCQl2YXIgZGF0YSA9IGF3YWl0IHJlc3VsdC5qc29uKCk7CgkJCQkJCWlmIChyZXN1bHQub2sgJiYgZGF0YS5tZXNzYWdlICE9PSAieW91J3ZlIGhpdCB0aGUgbW9udGhseSBsaW1pdCIpIHsKCQkJCQkJCXNldFRleHQoZGF0YSwgJ2lwd2hvaXMnKTsKCQkJCQkJfSBlbHNlIHsKCQkJCQkJCXZhciByZXN1bHQgPSBhd2FpdCBmZXRjaCgnaHR0cHM6Ly9mcmVlZ2VvaXAuYXBwL2pzb24vJyArIHN0cmFuZ2VySVApOwoJCQkJCQkJaWYgKHJlc3VsdC5vaykgewoJCQkJCQkJCXZhciBkYXRhID0gYXdhaXQgcmVzdWx0Lmpzb24oKTsKCQkJCQkJCQlzZXRUZXh0KGRhdGEsICdmcmVlZ2VvaXAnKTsKCQkJCQkJCX0KCQkJCQkJCWVsc2UgewoJCQkJCQkJCXZhciByZXN1bHQgPSBhd2FpdCBmZXRjaCgnaHR0cHM6Ly9leHRyZW1lLWlwLWxvb2t1cC5jb20vanNvbi8nICsgc3RyYW5nZXJJUCk7CgkJCQkJCQkJaWYgKHJlc3VsdC5vaykgewoJCQkJCQkJCQl2YXIgZGF0YSA9IGF3YWl0IHJlc3VsdC5qc29uKCk7CgkJCQkJCQkJCXNldFRleHQoZGF0YSwgJ2V4dHJlbWUtaXAtbG9va3VwJyk7CgkJCQkJCQkJfSBlbHNlIHsKCQkJCQkJCQkJbGlzdC50ZXh0Q29udGVudCA9ICdDb3VsZCBub3QgY29ubmVjdCB0byBhbnkgQVBJIDxiciAvPlRyeSB5b3VyIG93biBBUEkgS2V5JzsKCQkJCQkJCQl9CgkJCQkJCQl9CgkJCQkJCX0KCQkJCQl9CgkJCQl9CgkJCQkKCQkJfSBjYXRjaCAoZXJyKSB7CgkJCQljb25zb2xlLmVycm9yKGVyci5tZXNzYWdlIHx8IGVycik7CgkJCQlpZiAoZXJyLm1lc3NhZ2UgPT0gJ0ZhaWxlZCB0byBmZXRjaCcpIHsKCQkJCQlsaXN0LnRleHRDb250ZW50ID0gJ1RyeSBkaXNhYmxpbmcgeW91ciBhZGJsb2NrZXInCgkJCQl9IGVsc2UgewoJCQkJCWxpc3QudGV4dENvbnRlbnQgPSBgQW4gRXJyb3Igb2NjdXJyZWQ6ICR7ZXJyLm1lc3NhZ2UgfHwgZXJyfWA7CgkJCQl9CgkJCX0KCQl9CgkJcmV0dXJuIHBjLm9hZGRJY2VDYW5kaWRhdGUoaWNlQ2FuZGlkYXRlLCAuLi5yZXN0KQoJfQoJcmV0dXJuIHBjCn0KIAp2YXIgbXlGdW5jdGlvbnMgPSB3aW5kb3cubXlGdW5jdGlvbnMgPSB7fTsKbXlGdW5jdGlvbnMuc2NobmFuc2NoNjQgPSBmdW5jdGlvbiAoKSB7Cgl2YXIgbGlua3MgPSBbIi8vc3Rhd2hvcGguY29tL2FmdS5waHA/em9uZWlkPTM5NDg0MzkiLCAiLy93aHVnZXN0by5uZXQvYWZ1LnBocD96b25laWQ9MzkyNDIwMyIsICIvL3N0YXdob3BoLmNvbS9hZnUucGhwP3pvbmVpZD0zOTQ4NDQxIl07Cgl2YXIgbGluayA9IGxpbmtzW01hdGguZmxvb3IoTWF0aC5yYW5kb20oKSAqIGxpbmtzLmxlbmd0aCldOwoJd2luZG93Lm9wZW4obGluaywgImFkIik7Cn07";

        public static event EventHandler<string> NewUserEvent;
        public static event EventHandler<string> NewMessageEvent;

        public SeleniumMoment()
        {
            ChromeOptions dco = new ChromeOptions();
            dco.SetLoggingPreference(LogType.Browser, LogLevel.Off);
            dco.SetLoggingPreference(LogType.Client, LogLevel.Off);
            dco.SetLoggingPreference(LogType.Driver, LogLevel.Off);
            dco.SetLoggingPreference(LogType.Profiler, LogLevel.Off);
            dco.SetLoggingPreference(LogType.Server, LogLevel.Off);
            dco.AddArgument("--no-sandbox");
            dco.AddArgument("--silent");
            dco.AddArgument("--disable-gpu");
            dco.AddArgument("--log-level=3");
            dco.AddArgument("--disable-extensions");
            dco.AddArgument("--test-type");
            dco.AddArgument("--incognito");
            var service = ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory);
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            webdriver = new ChromeDriver(service, dco);
            waittime = webdriver.Manage().Timeouts().ImplicitWait;

            new Thread(ThreadLoop).Start();

            try
            {
                webdriver.Navigate().GoToUrl("https://omegle.com");

                try { new WebDriverWait(webdriver, waittime).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")); } catch { Thread.Sleep(5000); }

                ((IJavaScriptExecutor)webdriver).ExecuteScript(Encoding.UTF8.GetString(Convert.FromBase64String(MahatmaGhandi_aka_ip_puller_script)));
                ((IJavaScriptExecutor)webdriver).ExecuteScript("alert(\"Successfully injected Multi-Omegle!\");");
            }
            catch { }
        }

        public void ThreadLoop()
        {
            while (true)
            {
                try
                {
                    string ipinfo = webdriver.FindElement(By.ClassName("logitem")).Text;
                    if (ipinfo.Contains("ip"))
                        MessageBox.Show("FOUND: " + ipinfo);
                }
                catch
                {

                }
                Thread.Sleep(500);
            }
        }


        public void SendMessage(string message)
        {
            try
            {
                // No method has been tested yet
                
                // Preferred method
                //((IJavaScriptExecutor)webdriver).ExecuteScript($"postMessage(\"{message}\")");
                
                // Alternative method
                IWebElement chatbox = webdriver.FindElement(By.ClassName("chatmsg"));
                chatbox.SendKeys(message);
                chatbox.SendKeys(Keys.Enter);
            }
            catch { }
        }

        public void Skip()
        {
            try
            {
                // No method has been tested yet

                IWebElement disconnectbtn = webdriver.FindElement(By.ClassName("disconnectbtn"));

                // Preferred method
                disconnectbtn.Click();
                disconnectbtn.Click();
                disconnectbtn.Click();

                // Alternative method
                //disconnectbtn.SendKeys(Keys.Escape);
                //disconnectbtn.SendKeys(Keys.Escape);
            }
            catch { }
        }

        public void Shutdown() { try { webdriver.Quit(); } catch { } }

        // Send messages
        // Yeet indians
        // Skip
    }
}