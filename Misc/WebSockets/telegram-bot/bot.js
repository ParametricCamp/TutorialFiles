// Load the Telegram API library
const TelegramBot = require('node-telegram-bot-api');

// Define our PRIVATE token! 
const token = '1696074482:AAFXeSWngZvO_URSXqzy0f8W31NrHZlFwQs';

// Initialize and connect the bot
const bot = new TelegramBot(token, {
    polling: true
});

// Create an /ECHO command
bot.onText(/\/echo (.+)/, function(msg, match) {
    console.log("Received an echo request");

    const data = match[1];

    bot.sendMessage(msg.chat.id, data);
});

// Create a /GREET command
bot.onText(/\/greet (.+)/, function(msg, match) {
    const res = `Hello ${match[1]}, how are you doing?`

    bot.sendMessage(msg.chat.id, res);
});



// // Respond to any message of any kind
// bot.on('message', function(msg) {
//     console.log('Received a message');
    
//     const res = `Hi ${msg.from.first_name}! I received your message: ${msg.text}`;

//     bot.sendMessage(msg.chat.id, res);
// });
