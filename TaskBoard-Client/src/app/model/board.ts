import { ICard } from "./card";
import { ICardList } from "./cardlist";

export interface IBoard{
    boardId: number;
    name: string;
    listDtos: ICardList[];
    cardDtos: ICard[];
}