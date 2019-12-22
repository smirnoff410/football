from __future__ import annotations
from typing import Optional
from sqlalchemy import create_engine
from sqlalchemy import Table, Column, String, Integer, MetaData, ForeignKey


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
        self.__db = create_engine('postgresql://postgres:12345@localhost/postgres')
        self.__meta = MetaData(self.__db)

    def CreateTables(self):
        player_table = Table('player', self.__meta,
                             Column('Id', Integer, primary_key=True),
                             Column('Name', String),
                             Column("Priority"), Integer)
        with self.__db.connect() as conn:
            player_table.create()
            insert_statement = player_table.insert().values(Id=1, Name='vlad', Priority=0)
            conn.execute(insert_statement)

    def InsertUser(self, name, priority):
        cur = self.__con.cursor()
        cur.execute(
            "INSERT INTO PLAYER (NAME, PRIORITY) VALUES ('" + name + "', " + str(priority) + ")"
        )
        self.__con.commit()
        self.__con.close()
