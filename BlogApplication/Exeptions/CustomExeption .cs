﻿namespace BlogApplication.Exeptions
{
    public class CustomExeption : Exception
    {
        public CustomExeption(string message) : base(message) { }
    }
}