﻿namespace Stocks.API.Models
{
    public class Div
    {
        public string secid { get; set; }
        public string isin { get; set; }
        public string registryclosedate { get; set; }
        public double value { get; set; }
        public string currencyid { get; set; }        
    }
}