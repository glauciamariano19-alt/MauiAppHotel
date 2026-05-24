using MauiAppHotel.Models;
using Microsoft.Maui.Controls;
using System;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(Quarto quarto, DateTime checkin, DateTime checkout, int quantidadeAdultos, int quantidadeCriancas)

    {
        InitializeComponent();

        var dias = (checkout - checkin).Days;

        BindingContext = new
        {
            quarto.Descricao,
            QuantidadeAdultos = quantidadeAdultos,
            QuantidadeCriancas = quantidadeCriancas,
            Checkin = checkin.ToString("dd/MM/yyyy"),
            Checkout = checkout.ToString("dd/MM/yyyy"),
            Dias = dias,
            ValorTotal = ((quarto.ValorDiariaAdulto + quarto.ValorDiariaCrainca) * dias).ToString("C")
        };
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();

    }
}



