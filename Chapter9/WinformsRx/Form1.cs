using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsRx
{
    public partial class WinFormsRx : Form
    {
        public WinFormsRx() => InitializeComponent();

        private void WinFormsRx_Load(object sender, EventArgs e)
        {
            IObservable<string> searchTerm = Observable.FromEventPattern<EventArgs>(textBox, "TextChanged")
                .Select(selector: x => ((TextBox)x.Sender).Text)
                .Throttle(TimeSpan.FromMilliseconds(5000));

            searchTerm.ObserveOn(new ControlScheduler(this))
                .Subscribe(term => label.Text = term);
        }
    }
}
