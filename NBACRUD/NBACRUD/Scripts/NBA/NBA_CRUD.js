$(function () {
    var gameid, team1index, team2index = null;

    //Teams array
    var NBATeams = ["Atlanta Hawks", "Boston Celtics", "Brooklyn Nets", "Charlotte Bobcats",
        "Chicago Bulls", "Cleveland Cavaliers", "Dallas Mavericks", "Denver Nuggets",
        "Detroit Pistons", "Golden State Warriors", "Houston Rockets", "Indiana Pacers",
        "LA Clippers", "LA Lakers", "Memphis Grizzlies", "Miami Heat", "Milwaukee Bucks",
        "Minnesota Timberwolves","New Orleans Hornets", "New York Knicks", "Oklahoma City Thunder",
        "Orlando Magic", "Philadelphia Sixers", "Phoenix Suns", "Portland Trail Blazers",
        "Sacramento Kings", "San Antonio Spurs", "Toronto Raptors", "Utah Jazz", "Washington Wizards"]

    //Populate select inputs with values
    var list1 = $('select')[0];
    var list2 = $('select')[1];
    var list3 = $('select')[2];
    var list4 = $('select')[3];
    $.each(NBATeams, function (index, text) {
        list1.options[list1.options.length] = new Option(text, text);
        list2.options[list2.options.length] = new Option(text, text);
        list3.options[list3.options.length] = new Option(text, text);
        list4.options[list4.options.length] = new Option(text, text);
    });

    $("#nbaGames").tablesorter();

    //ADD GAME
    //$("#nbaGames").tablesorter({ sortList: [[0, 0], [1, 0]] });
    $('#addGame').click(function () {
        $.ajax({
            type: 'POST',
            datatype: 'json',
            contentType: "application/json",
            data: JSON.stringify({
                "Team1": $("#Team1add").val(),
                "Team2": $("#Team2add").val(),
                "Period": $("#Periodadd").val(),
                "Time": $("#Timeadd").val(),
                "Description": $("#Descriptionadd").val(),
                "ScoreTeam1": $("#ScoreTeam1add").val(),
                "ScoreTeam2": $("#ScoreTeam2add").val()
            }),
            url: '/api/Game',
            success: function (response) {
                location.reload();
                console.log(response);
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    //EDIT A GAME
    $('#editGame a').click(function () {
        gameid = $(this).attr("id");
        
        $.ajax({
            type: 'GET',
            datatype: 'json',
            accept: "application/json",
            url: '/api/Game/' + $(this).attr("id"),
            success: function (data) {
                $("#Team1edit").val($.trim(data.Team1));
                $("#Team2edit").val($.trim(data.Team2));
                $("#Periodedit").val(data.Period);
                $("#Timeedit").val(data.Time);
                $("#Descriptionedit").val(data.Description);
                $("#ScoreTeam1edit").val(data.ScoreTeam1);
                $("#ScoreTeam2edit").val(data.ScoreTeam2);
                //console.log(data);
            },
            error: function (response) {
                console.log(response);
            }
        });
    });

    //save edited game
    $("#editSave").click(function () {
        $.ajax({
            type: 'PUT',
            datatype: 'json',
            contentType: "application/json",
            data: JSON.stringify({
                "ID": gameid + "",
                "Team1": $("#Team1edit").val(),
                "Team2": $("#Team2edit").val(),
                "Period": $("#Periodedit").val(),
                "Time": $("#Timeedit").val(),
                "Description": $("#Descriptionedit").val(),
                "ScoreTeam1": $("#ScoreTeam1edit").val(),
                "ScoreTeam2": $("#ScoreTeam2edit").val()
            }),
            url: '/api/Game/' + gameid,
            success: function (response) {
                location.reload();
                console.log(response);
            },
            error: function (response) {
                console.log(response);
                gameid = null;
            }
        });
    })
});