//Export to CSV
function exporttocsv() {
    $("#nbaGames").tableToCSV({
        //filename: 'NBA Games'
    });
}

//Export to Excel
function exporttoexcel() {
    $("#nbaGames").table2excel({
        name: "Table2Excel",
        filename: "NBAGames",
        fileext: ".xls"
    });
}