using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebPageAutomator;
using System.Threading;
using InfluxDBStorage;
using InfluxDBStorage.Types;

namespace OilPriceTracker
{
    public partial class Application : Form
    {
        /// <summary>
        /// MetricsStorage object
        /// </summary>
        MetricsStorage metrics = null;

        /// <summary>
        /// Thread handle for reading prices
        /// </summary>
        Thread th;

        public Application()
        {
            InitializeComponent();
            metrics = new MetricsStorage("http://localhost:8086", "writer", "develop");
        }

        private void buttonGetOilPrices_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(ReadPrices);
            th.Start();
        }

        delegate void SetUiTextCallBack(string text);

        private void AddTeboilListBoxPrice(string textToInsert)
        {
            if(this.listBoxOilPrices_Teboil.InvokeRequired)
            {
                SetUiTextCallBack d = new SetUiTextCallBack(AddTeboilListBoxPrice);
                this.Invoke(d, new object[] { textToInsert });
            }
            else
            {
                listBoxOilPrices_Teboil.Items.Add(textToInsert);
            }
        }

        private void AddLampopuistoListBoxPrice(string textToInsert)
        {
            if (this.listBoxOilPrices_Lampopuisto.InvokeRequired)
            {
                SetUiTextCallBack d = new SetUiTextCallBack(AddLampopuistoListBoxPrice);
                this.Invoke(d, new object[] { textToInsert });
            }
            else
            {
                listBoxOilPrices_Lampopuisto.Items.Add(textToInsert);
            }
        }

        private void AddNesteListBoxPrice(string textToInsert)
        {
            if (this.listBoxOilPrices_Neste.InvokeRequired)
            {
                SetUiTextCallBack d = new SetUiTextCallBack(AddNesteListBoxPrice);
                this.Invoke(d, new object[] { textToInsert });
            }
            else
            {
                listBoxOilPrices_Neste.Items.Add(textToInsert);
            }
        }

        private void ReadPrices()
        { 
            DecimalMeasurements measurements = new DecimalMeasurements();

            try
            {
                using (WebPageHandler teboilPage = new WebPageHandler("https://tilaus.teboil.fi/cgi-bin/nph-cgi/hintalaskuri"))
                {
                    teboilPage.OpenWebBrowser();
                    teboilPage.EnterTextToControl("/html/body/form/div[4]/div/div/div[2]/table/tbody/tr[4]/td/table/tbody/tr[2]/td[2]/input", "1000");
                    teboilPage.EnterTextToControl("/html/body/form/div[4]/div/div/div[2]/table/tbody/tr[4]/td/table/tbody/tr[3]/td[2]/input", "87500");
                    teboilPage.ClickItem("/html/body/form/div[4]/div/div/div[2]/table/tbody/tr[4]/td/table/tbody/tr[15]/td[2]/span/span/table/tbody/tr/td/a");
                    string text = teboilPage.GetText("/html/body/form/div[4]/div/div/div[2]/table/tbody/tr[4]/td/table/tbody/tr[21]/td[2]/table/tbody/tr/td/table/tbody/tr[3]/td[3]");

                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] lines = text.Split(stringSeparators, StringSplitOptions.None);
                    string[] teboilPrices = lines[0].Split(' ');

                    decimal teboilPrice = Convert.ToDecimal(teboilPrices[3].Replace(".", ","));
                    
                    AddTeboilListBoxPrice(teboilPrice.ToString());

                    teboilPage.CloseWebBrowser();

                    measurements.AddMeasurement("Teboil", teboilPrice);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Exception: {0}", ex.ToString()));
                measurements.AddMeasurement("Teboil", 0.0);
                AddTeboilListBoxPrice("---");
            }

            try
            {
                using (WebPageHandler lampopuistoPage = new WebPageHandler("https://www.lampopuisto.fi/fi/yksityisille/lammitysoljyn-hinta"))
                {
                    lampopuistoPage.OpenWebBrowser();
                    lampopuistoPage.ClickItem("/html/body/div[1]/div/nav[2]/ul/li[1]/a");
                    lampopuistoPage.EnterTextToControl("/html/body/div[1]/section[2]/div[1]/form[1]/div[2]/div/div/input", "87500");
                    lampopuistoPage.ClickItem("/html/body/div[1]/section[2]/div[1]/form[1]/div[4]/div[1]/div[2]/div/label");
                    lampopuistoPage.EnterTextToControl("/html/body/div[1]/section[2]/div[1]/form[1]/div[4]/div[2]/div[2]/div/input", "1000");
                    Thread.Sleep(2000);

                    string lampopuistoPrices = lampopuistoPage.GetText("/html/body/div[1]/section[2]/div[3]/div/form/div[4]/div");
                    decimal lampopuistoPrice = Convert.ToDecimal(lampopuistoPrices);

                    AddLampopuistoListBoxPrice(lampopuistoPrice.ToString());

                    lampopuistoPage.CloseWebBrowser();

                    measurements.AddMeasurement("Lampopuisto", lampopuistoPrice);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(String.Format("Exception: {0}", ex.ToString()));
                measurements.AddMeasurement("Lampopuisto", 0.0);
                AddLampopuistoListBoxPrice("---");
            }

            try
            {
                using (WebPageHandler nestePage = new WebPageHandler("https://www.neste.fi/lammitysoljytilaus"))
                {
                    nestePage.OpenWebBrowser();
                    nestePage.EnterTextToControl("//*[@id=\"edit-county-number\"]", "87500");
                    nestePage.ClickItem("//*[@id=\"edit-submit\"]");
                    Thread.Sleep(6000);
                    string nestePrices = nestePage.GetText("/html/body/div[1]/div/div/div[2]/div[2]/div[2]/div[2]/div/div/div[1]/div/div[4]");

                    string[] nestePriceList = nestePrices.Split(' ');
                    nestePrices = (Convert.ToDecimal(nestePriceList[0]) * 1000).ToString();
                    decimal nestePrice = Convert.ToDecimal(nestePrices);

                    // Delivery costs
                    nestePrice += 50;

                    AddNesteListBoxPrice(nestePrice.ToString());

                    nestePage.CloseWebBrowser();

                    measurements.AddMeasurement("Neste", nestePrice);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Exception: {0}", ex.ToString()));
                measurements.AddMeasurement("Neste", 0.0);
                AddNesteListBoxPrice("---");
            }

            metrics.SaveMetricsToInflux("Test", "oil-prices", measurements);
        }

        private void buttonStartReadingPrices_Click(object sender, EventArgs e)
        {
            th = new Thread(TimerThread);
            th.Start();
        }

        private void TimerThread()
        {
            while (true)
            {
                th = new Thread(ReadPrices);
                th.Start();

                // Wait 15 minutes before next read
                Thread.Sleep(600000*2);

                if (th.IsAlive)
                    th.Abort();

            }
        }

        /// <summary>
        /// Form losing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kill prices reading thread if it is alive
            if(th != null)
            {
                if (th.IsAlive == true)
                    th.Abort();
            }
        }
    }
}
