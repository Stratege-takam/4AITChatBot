class ChatBot {
    constructor() {
        this.btn = $("#chatbotBtn");
        this.setValue = $("#ChatSetValue");
        this.body = $("#chatbot_body");
        this.choose = $("#chatbotChoice");
        this.search = $("#chatbotSearch");
        this.formajax = $("#chatbotForm");
        this.clientChat = $("#chatBotClient");
        this.response = $("#ChatResponse");
        this.responseSingle = $("#ChatResponseSingle");
        this.ChatbotPreMessage = $("#ChatbotPreMessage");
        this.formjs = document.getElementById("chatbotForm");
    }
}
$(function () {

    var chatBot = new ChatBot();
    var client = false;
    var begin = false;
    var resultSigne = null;
    scrollBody();
    chatBot.search.focus();

   
    var chat = $.connection.chatbotHub;


    //reception de la reponse par les deux parties 
    chat.client.recieveClientAndServer = function (singleMessage, response) {
        if (singleMessage) {
            // cas du single message 
            //chatBot.body.append(response);
        }
        else {
            //cas de plusieurs messages
            chatBot.body.html(response);
        }
        scrollBody();
    }

     // serveur reçoit la question en provenance du client
    chat.client.recieveServer = function (question) {
        post(chatBot.formajax, { search: question }, function (data) {
            chatBot.body.append(data);
            resultSigne = data;
            resultAll = null;
            //Si le message est recu alors on va declancher l'evement du click pour envoyer le 
            // resultat aux deux parties
           // chatBot.btn.trigger("click");
            scrollBody();
            setTimeout(function () {
                post(chatBot.formajax, { search: question }, function (result) {
                  
                    resultSigne = null;
                    resultAll = result;
                    //chatBot.btn.attr("disabled", false);
                    //Si le message est recu alors on va declancher l'evement du click pour envoyer le 
                    // resultat aux deux parties
                    chatBot.btn.trigger("click");
                }, null, function (result) {
                    chatBot.search.val(null);
                    scrollBody();

                    
                });
            }, 3000);

        }, chatBot.ChatbotPreMessage.val(), function (data) {

        });
    }

    // demarer la connexion
    $.connection.hub.start().done(function () {


        chatBot.btn.click(function () {
            if (resultSigne !== null) {
                // cas du single message 
                chat.server.sendServer(true, resultSigne);
            }
            if (resultAll !== null) {
                //cas de plusieurs messages
                chat.server.sendServer(false, resultAll);
            }
            //chatBot.btn.attr("disabled", true);
        });

        //lorsque l'etat du check change, 
        chatBot.clientChat.change(function () {
            client = chatBot.clientChat.is(":checked");
            //alert(client);
            
            if (client) {
                GenerateQuestion();
            }
            var time = setInterval(function () {
                if (client) {
                    GenerateQuestion();
                }
                else {
                    clearInterval(time);
                }
                }, 10000);
        });
        

    });


    function GenerateQuestion() {
        // il doit generer une question
        post(chatBot.formajax, { search: null }, function (response) {
            //la question est générée
            //console.log(response);
            var question = response.Key;



            //modifier le texte du client
            post(chatBot.formajax, { search: question }, function (response) {
                console.log(response);
                chatBot.body.append(response);
            }, chatBot.clientChat.data("action"), function (result) {
                scrollBody();
            });



            //envoyer la question au serveur 
            chat.server.sendClient(question);

        }, chatBot.clientChat.val(), function (response) {
            chatBot.search.val(null);
            scrollBody();
        });
    }


   

    function scrollBody() {
        chatBot.body.scrollTop(chatBot.body.prop('scrollHeight'));
    }

    function post(form,data, callback, action = null, completeCallback = null) {
        form = form[0];
        // $.validator.unobtrusive.parse(form);
       // console.log(form);
       
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
