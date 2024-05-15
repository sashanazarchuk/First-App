import { CardPriority } from "./cardpriority";


export interface ICard {
    id: number;
    name: string;
    description: string;
    date: Date;
    priority: CardPriority;
    boardId: number;
    board: string;
    cardListId: number;
    cardList: string;
}