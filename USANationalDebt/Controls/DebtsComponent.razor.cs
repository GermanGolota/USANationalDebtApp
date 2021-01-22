using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace USANationalDebt.Controls
{
    public partial class DebtsComponentBase : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        [Parameter]
        public string Language { get; set; }

        //language : (Name(external/internal):value)
        public Dictionary<string, Dictionary<string, string>> LanguageDictionary =
            new Dictionary<string, Dictionary<string, string>>();

        public DebtModelRead ExternalModel { get; set; }
        public DebtModelRead InternalModel { get; set; }

        public bool IsChecked { get; set; } = false;

        public void ChangeState(bool Checked)
        {
            IsChecked = Checked;
        }

        Random random = new Random(DateTime.Now.Second);

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            swaggerClient client = new("http://localhost:44333/", Http);

            ExternalModel = await client.ExternalDebtAsync();
            InternalModel = await client.InternalDebtAsync();

            TimeSpan span = DateTime.Now - ExternalModel.Day;
            ExternalModel.Day = DateTime.Now;
            ExternalModel.Debt += span.TotalSeconds * ExternalModel.Increase;

            span = DateTime.Now - InternalModel.Day;
            InternalModel.Day = DateTime.Now;
            InternalModel.Debt += span.TotalSeconds * InternalModel.Increase;

            InitializeDictionaries();

            await Start();
        }

        public void InitializeDictionaries()
        {
            Dictionary<string, string> RussianDict = new Dictionary<string, string>();
            RussianDict.Add("External", "Внешний долг США");
            RussianDict.Add("Internal", "Внутренний долг США");
            LanguageDictionary.Add("Russian", RussianDict);

            Dictionary<string, string> EnglishDict = new Dictionary<string, string>();
            EnglishDict.Add("External", "Intergovernmental debt");
            EnglishDict.Add("Internal", "Public debt");
            LanguageDictionary.Add("English", EnglishDict);

            Dictionary<string, string> ArabicDict = new Dictionary<string, string>();
            ArabicDict.Add("External", "الديون الخارجية للولايات المتحدة");
            ArabicDict.Add("Internal", "الديون المحلية الأمريكية");
            LanguageDictionary.Add("Arabic", ArabicDict);
        }

        async Task Start()
        {
            await Task.Delay(1000);
            while (true)
            {
                await Timer();
            }

        }

        async Task Timer()
        {
            int delay = random.Next(500, 1500);
            await Task.Delay(delay);
            await AfterTime();
        }

        async Task AfterTime()
        {
            double increment = Math.Round(ExternalModel.Increase * ((double)random.Next(60, 140) / 100), 2);
            ExternalModel.Debt += increment;

            increment = Math.Round(InternalModel.Increase * ((double)random.Next(60, 140) / 100), 2);
            InternalModel.Debt += increment;

            StateHasChanged();
        }
    }
}
