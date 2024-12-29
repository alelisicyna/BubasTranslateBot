using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using DeepL;



class Bot {
  static void Main() {
    // string authKey = "";
    // Translator translator = new Translator(authKey);

    using CancellationTokenSource cts = new CancellationTokenSource();
    TelegramBotClient bot = new TelegramBotClient("", cancellationToken: cts.Token);
    bot.OnMessage += OnMessage;

    Console.WriteLine("--BOT RUN--");
    Console.ReadLine();
    cts.Cancel();

    async Task OnMessage(Message msg, UpdateType type) {
      if (msg.Text is null) {
        return;
      }

      /* TranslateTextAsync translatedText = await translator.TranslateTextAsync(
          msg.Text,
          LanguageCode.Polish,
          LanguageCode.English
      ); 
      await bot.SendMessage(msg.Chat, $"{translatedText}"); */
      await bot.SendMessage(msg.Chat, $"{msg.Text}");
      Console.WriteLine($"@{msg.From.Username} ({msg.From.Id}): {msg.Text}");
    }
  }
}