import { ICard } from "./card";

export interface ICardList {
    cardListId: number;
    name: string;
    boardId: number;
    cards: ICard[];
    cardCount: number;
}