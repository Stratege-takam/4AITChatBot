class ChatBot {
    constructor() {
        this.btn = $("#chatbotBtn");
        this.body = $("#chatbot_body");
        this.choose = $("#chatbotChoice");
        this.search = $("#chatbotSearch");
        this.formajax = $("#chatbotForm");
        this.audioplays = $("#chatBotPlay");
        this.formjs = document.getElementById("chatbotForm");
    }
}

$(function () {

    var chatBot = new ChatBot();
    var play = false;
    scrollBody();
    chatBot.search.focus();

    //lorsque l'etat du check change, 
    chatBot.audioplays.change(function () {
        play = chatBot.audioplays.is(":checked");
    });

    //click
    chatBot.btn.click(function (e) {
        e.preventDefault();
        post(chatBot.formajax, {search: chatBot.search.val()}, function (result) {
            //console.log("success", result);
            chatBot.body.html(result);
        }, null, function (result) {
            chatBot.search.val(null);
            scrollBody();
            if (play) {
                var reponse = $(".chatItem span ").last().html();
                post(chatBot.formajax, { text: reponse }, function (param) { },chatBot.audioplays.data("action"), function (param) {
                    console.log(param);
                });
            }
        });
    });

    //saisir 
    chatBot.search.keydown(function (e) {
        // si on click sur la touche entré
        if (e.keyCode === 13) {
            e.preventDefault();
            chatBot.btn.trigger("click");
        }
    });

    function scrollBody() {
        chatBot.body.scrollTop(chatBot.body.prop('scrollHeight'));
    }


    function post(form,data, callback, action = null, completeCallback = null) {
        form = form[0];
        // $.validator.unobtrusive.parse(form);
       // console.log(form);
       
        console.log(data);

        var ajaxConf = {
            type: 'POST',
            url: action === null ? form.action : action,
            data: data,
            success: function (response) {
                callback(response);
            },
            error: function (error) {
                console.log(error);
            },
            complete: function (response) {
                if (completeCallback !== null) {
                    completeCallback(response);
                }
            }
        };
        
        $.ajax(ajaxConf);
        
    }
    /**
     * la fonction get est une fonction ajax qui permet de faire toutes les requêtes
     * de type get dans la base de donné et d'une manière asynchrone
     * le callback est une fonction qui sera appelle en cas de sucess 
     * le data est par defaut null, c'est la donnée que l'on souhaite transmettre
     * à la requête.
     * completecallback est appelé quand la requête c'est terminée
     * @param {any} action
     * @param {any} callback
     * @param {any} data
     * @param {any} completeCallback
     */
    function get(action, callback, data = null, completeCallback = null) {

        var ajaxConf = {
            type: 'GET',
            url: action,
            data: data,
            success: function (response) {
                callback(response);
            },
            error: function (error) {
                console.log(error);
            },
            complete: function (response) {
                if (completeCallback !== null) {
                    completeCallback(response);
                }
            }
        };

        $.ajax(ajaxConf);

    }

});