using CsvHelper.Configuration.Attributes;

namespace Movies.Services.ReaderService.Dto;

public class MovieReaderDto
{
    //Series_Title,
    [Name("Series_Title")]
    public string Series_Title { get; set; }
    //Released_Year,
    [Name("Released_Year")]
    public string Released_Year { get; set; }
    //Certificate,
    public string Certificate { get; set; }
    //Runtime,
    public int Runtime { get; set; }
    //Genre,
    public string Genre { get; set; }
    //Subgenre,
    public string Subgenre { get; set; }
    //Subgenre 1,
    [Name("Subgenre 1")]
    public string Subgenre1 { get; set; }
    //IMDB_Rating,
    public double IMDB_Rating { get; set; }
    //Meta_score,
    public string Meta_score { get; set; }
    //Director,
    public string Director { get; set; }
    //Star1,
    public string Star1 { get; set; }
    //Star2,
    public string Star2 { get; set; }
    //Star3,
    public string Star3 { get; set; }
    //Star4,
    public string Star4 { get; set; }
    //No_of_Votes,
    public int No_of_Votes { get; set; }
    //Gross
    public string Gross { get; set; }
}