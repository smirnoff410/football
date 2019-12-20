import bs4 as bs4
import requests


class User:
    FullName = ""
    Priority = 0

    def __init__(self, priority):
        self.Priority = priority

    @staticmethod
    def _get_user_name_from_vk_id(user_id):
        request = requests.get("https://vk.com/id" + str(user_id))
        bs = bs4.BeautifulSoup(request.text, "html.parser")

        user_name = User._clean_all_tag_from_str(bs.findAll("title")[0])

        return user_name

    @staticmethod
    def _clean_all_tag_from_str(string_line):

        """
        Очистка строки stringLine от тэгов и их содержимых
        :param string_line: Очищаемая строка
        :return: очищенная строка
        """

        result = ""
        not_skip = True
        for i in list(string_line):
            if not_skip:
                if i == "<":
                    not_skip = False
                else:
                    result += i
            else:
                if i == ">":
                    not_skip = True

        return result
