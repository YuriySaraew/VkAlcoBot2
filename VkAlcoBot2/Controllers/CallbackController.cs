using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace VkAlcoBot2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        [HttpPost]
        public IActionResult Callback([FromBody] JObject data)
        {
            // Проверка, что запрос пришёл от VK
            if (data["secret"].ToString() != "vk1.a.X3deDIjVbjqMaQqwh0pQU3dG9oQAQCy5ScnS0_DOo8M7_uRH56bPOkLRoEYbNj_tHfJ0w8kcx2D6hROHiftKiI_49oxFT1hg6lfIxqXZR13qfziR4tXsV9akHb0rbd9EAWZ_duWkGLs3PWHFe2o-cbb-QyMcCFq320shc89cXxiSlPNS3OkrXIrbtysLbxXOREczWT03DoahoLwvf4Go4g")
            {
                return Ok("ok");
            }

            // Обработка входящего сообщения
            var type = data["type"].ToString();
            switch (type)
            {
                case "confirmation":
                    // Возвращаем строку, которую выдал VK при подтверждении сервера
                    return Ok("2a8cec42");
                case "message_new":
                    // Обработка нового сообщения
                    var message = data["object"]["message"];
                    var userId = message["from_id"].ToString();
                    var text = message["text"].ToString();
                    var peerId = message["peer_id"].ToString(); // Получаем идентификатор беседы или пользователя

                    // Обработка текста и формирование ответа
                    var response = ProcessMessage(text);

                    // Отправка ответа
                    // Отправляем сообщение обратно, учитывая peer_id
                    // vkApi.Messages.Send(new MessagesSendParams
                    // {
                    //     PeerId = peerId,
                    //     Message = response
                    // });

                    return Ok("ok");
                default:
                    return Ok("ok");
            }
        }

        // Логика обработки входящего сообщения
        private string ProcessMessage(string text)
        {
            // Здесь ты можешь реализовать логику своего чат-бота
            // Например, вернуть приветственное сообщение
            return "Привет, я чат-бот на C#!";
        }
    }
}