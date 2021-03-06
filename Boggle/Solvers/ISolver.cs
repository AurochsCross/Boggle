﻿using Boggle.Models.Results;
namespace Boggle
{
    public interface ISolver
    {
        // board: 'q' represents the 'qu' Boggle cube
        IResults FindWords(char[,] board);
    }
}
