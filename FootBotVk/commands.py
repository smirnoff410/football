from __future__ import annotations
from abc import ABC, abstractmethod
from User import User
from match import Match
import pickle
import os


class Invoker:
    set_command = None

    def set_command(self, command: Command):
        self._set_command = command

    def run(self) -> None:
        return self._set_command.execute()


class Command(ABC):

    @abstractmethod
    def execute(self) -> None:
        pass


class SetCommand(Command):

    def __init__(self, text: str) -> None:
        self.__text = text

    def execute(self) -> None:
        users = dict()
        if os.path.getsize('users.txt') > 0:
            with open('users.txt', 'rb') as file:
                users = pickle.load(file)
                file.close()

        split = self.__text.split(' ')
        user = User(split[2])
        user.FullName = User._get_user_name_from_vk_id(split[1])
        users.update({split[1]: user})
        with open('users.txt', 'wb') as output:
            pickle.dump(users, output)
            output.close()
        return "Добавлен приоритет " + user.Priority + " пользователю " + user.FullName


class RemoveCommand(Command):

    def __init__(self, text: str) -> None:
        self.__text = text

    def execute(self):
        users = dict()
        if os.path.getsize('users.txt') > 0:
            with open('users.txt', 'rb') as file:
                users = pickle.load(file)
                file.close()

        split = self.__text.split(' ')
        user = users.pop(split[1])

        with open('users.txt', 'wb') as output:
            pickle.dump(users, output)
            output.close()
        return "Приоритет у пользователя " + user.FullName + " удалён"


class StartMatchCommand(Command):

    def __init__(self) -> None:
        self.__match = Match()

    def execute(self) -> None:
        self.__match.set_status_match(True)
        return "Событие матча создано, скорее подтверждайте участия!"


class StopMatchCommand(Command):
    def __init__(self) -> None:
        self.__match = Match()

    def execute(self) -> None:
        if self.__match.get_status_match():
            self.__match.set_status_match(False)
            players = self.__match.get_players_string_from_team()
            self.__match.clear_team()
            return "Команда собрана! Играют: " + players
        else:
            return "К сожалению события матча ещё не создано, введите команду /start"


class ConfirmParticipationCommand(Command):

    def __init__(self, id: int) -> None:
        self.__match = Match()
        self.__users = dict()
        self.__user_id = id
        if os.path.getsize('users.txt') > 0:
            with open('users.txt', 'rb') as file:
                self.__users = pickle.load(file)
                file.close()

    def execute(self) -> None:
        if self.__match.get_status_match():
            name = User._get_user_name_from_vk_id(self.__user_id)
            if name in self.__users:
                if name in self.__match.get_team():
                    return "Чел с именем " + name + ", ты уже в заявке"
                else:
                    self.__match.add_player_to_team(name)
                    return name + " добавлен в список команды"
            else:
                return "Ошибка :(, пользователь с именем " + name + " не найден"
        else:
            return "К сожалению события матча ещё не создано, введите команду /start"


class CancelConfirmParticipationCommand(Command):

    def __init__(self, id: int) -> None:
        self.__match = Match()
        self.__users = dict()
        self.__user_id = id
        if os.path.getsize('users.txt') > 0:
            with open('users.txt', 'rb') as file:
                self.__users = pickle.load(file)
                file.close()

    def execute(self) -> None:
        if self.__match.get_status_match():
            name = User._get_user_name_from_vk_id(self.__user_id)
            if name in self.__users:
                if name in self.__match.get_team():
                    self.__match.remove_player_from_team(name)
                    return name + " удален из списка команды"
                else:
                    return "Чел с именем " + name + ", ты и не подавал заявку"
            else:
                return "Ошибка :(, пользователь с именем " + name + " не найден"
        else:
            return "К сожалению события матча ещё не создано, введите команду /start"


class HelpCommand(Command):

    def execute(self) -> None:
        return "Команды: \n/set [Имя Фамилия] [Приоритет(от 0 до 1)] - Добавление пользователя в базу и выставление ему приоритета\n" + "/start - начало приёма заявок на матч\n" + "/stop - конец приёма заявок на матч\n" + "/+ - подтверждение участия в матче\n" + "/- - отмена подтверждения участия в матче\n"


class ClearCommand(Command):

    def __init__(self) -> None:
        self.__users = dict()
        with open("users.txt", encoding="utf8") as file:
            self.__users = eval(file.read())

    def execute(self) -> None:
        self.__users.clear()
        return "База очищена успешно"
