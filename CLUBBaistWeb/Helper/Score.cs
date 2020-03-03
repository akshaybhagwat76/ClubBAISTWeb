using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Author : Akshay Bhagwat
/// SKype Id : akshaybhagwat76@hotmail.com
/// Gmail : akshaybhagwat76@gmail.com
/// Freelancer : https://www.freelancer.com/u/akshaybhagwat76
/// COntact : +91-7383328380
/// </summary>
public class Score
{
    public string Tee { get; set; }
    public List<int> scores { get; set; }
    public int Total { get; set; }
    public double HandicapDifferential { get; set; }
    public Score(string tee, int total)
    {
        Tee = tee;
        Total = total;
        scores = new List<int>();
    }
}


