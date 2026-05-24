using MauiAppHotel.Models;
using Microsoft.Maui.Controls;
using System;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        App PropriedadesApp;
        private DateTime data_selecionada_checkin;

        public ContratacaoHospedagem()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;

            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
            dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);

        }
        private async void OnAvancarClicked(object sender, EventArgs e)
        {
            try
            {
                var quartoSelecionado = (Quarto)pck_quarto.SelectedItem;

                if (quartoSelecionado == null)
                {
                    await DisplayAlertAsync("OPS", "Você precisa escolher uma suíte.", "OK");
                    return;
                }


                int qtdAdultos = (int)stp_adultos.Value;
                int qtdCriancas = (int)stp_criancas.Value;

                await Navigation.PushAsync(
                    new HospedagemContratada(
                        quartoSelecionado,
                        dtpck_checkin.Date.Value,
                        dtpck_checkout.Date.Value,
                        qtdAdultos,
                        qtdCriancas
                    )
                );
            }               
            catch (Exception ex)
            {
                await DisplayAlertAsync("OPS", ex.Message, "OK");
            }
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            var elemento = (DatePicker)sender;

            data_selecionada_checkin = (DateTime)elemento.Date;
            if (data_selecionada_checkin != DateTime.MinValue)
            {
                dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
                dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
            }
            
        }
    }
}
