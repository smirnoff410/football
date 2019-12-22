import random
import vk_api

from vk_api.bot_longpoll import VkBotLongPoll, VkBotEventType
from commands import *
from DbConnection import *


def write_msg(peer_id, message):
    vk.method('messages.send', {'peer_id': peer_id, 'message': message, 'random_id': random.randint(0, 2048)})


db = DbContext()
db.CreateTables()

# API-ключ созданный ранее
token = "5b2626444cb4bdbf04e4f7986caf38f4e931a86aa660ee163ed2363431b8b38c166f067c679d9774e8274"

# Авторизуемся как сообщество
vk = vk_api.VkApi(token=token)

vk._auth_token()

vk.get_api()

# Работа с сообщениями
longpoll = VkBotLongPoll(vk, 189953873)

invoker = Invoker()

for event in longpoll.listen():
    if event.type == VkBotEventType.MESSAGE_NEW:
        text = event.object.message['text']
        peer_id = event.object.message['peer_id']
        from_id = event.object.message['from_id']

        print(event)
        print(text)
        print(peer_id)
        print(from_id)

        if peer_id != from_id:
            try:
                text = text.replace("[club189953873|Футбольчик]", "").strip()
                if text.find('/setpriority') != -1:
                    invoker.set_command(SetCommand(text))
                if text.find('/removeplayer') != -1:
                    invoker.set_command(RemoveCommand(text))
                elif text.find('/start') != -1:
                    invoker.set_command(StartMatchCommand())
                elif text.find('/+') != -1:
                    invoker.set_command(ConfirmParticipationCommand(from_id))
                elif text.find('/-') != -1:
                    invoker.set_command(CancelConfirmParticipationCommand(from_id))
                elif text.find('/stop') != -1:
                    invoker.set_command(StopMatchCommand())
                elif text.find('/help') != -1:
                    invoker.set_command(HelpCommand())
                elif text.find('/clear') != -1:
                    invoker.set_command(ClearCommand())

                write_msg(peer_id, invoker.run())
            except Exception as e:
                print(e)
                write_msg(peer_id, "Упс произошла какая то ошибка")
