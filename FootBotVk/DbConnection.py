from __future__ import annotations
from typing import Optional
import psycopg2


class SingletonMeta(type):
    """
    В Python класс Одиночка можно реализовать по-разному. Возможные способы
    включают себя базовый класс, декоратор, метакласс. Мы воспользуемся
    метаклассом, поскольку он лучше всего подходит для этой цели.
    """

    _instance: Optional[Singleton] = None

    def __call__(self) -> Singleton:
        if self._instance is None:
            self._instance = super().__call__()
        return self._instance


class DbContext(metaclass=SingletonMeta):

    def __init__(self):
        self.__con = psycopg2.connect(
            database="postgres",
            user="postgres",
            password="",
            host="127.0.0.1",
            port="5432"
        )

    def CreateTable(self):
        cur = self.__con.cursor()
        cur.execute('''CREATE TABLE STUDENT  
             (ADMISSION INT PRIMARY KEY NOT NULL,
             NAME TEXT NOT NULL,
             AGE INT NOT NULL,
             COURSE CHAR(50),
             DEPARTMENT CHAR(50));''')
        self.__con.commit()