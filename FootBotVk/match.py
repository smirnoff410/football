from DbConnection import DbContext


class Match:

    def __init__(self):
        self.__status = False
        self.__team = list()
        self.__db = DbContext()

    def start_match(self):
        self.__db.CreateTable()

    def get_status_match(self):
        return self.__status

    def set_status_match(self, status):
        self.__status = status

    def add_player_to_team(self, name):
        self.__team.append(name)

    def remove_player_from_team(self, name):
        self.__team.remove(name)

    def get_team(self):
        return self.__team

    def clear_team(self):
        self.__team.clear()

    def get_players_string_from_team(self):
        players = ""
        for item in self.__team:
            players += item + ", "
        return players
