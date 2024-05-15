import { Component, OnInit, ViewChild } from '@angular/core';
import { IBoard } from 'src/app/model/board';
import { CardPriority } from 'src/app/model/cardpriority';
import { BoardService } from 'src/services/boardService';
import { CardService } from 'src/services/cardService';
 
@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  boards!: IBoard[];
  selectedBoardId!: number;
  selectedCardId: number | null = null;
  selectedBoard: IBoard | null = null;
  selectedListId!: number ;

 
  constructor(private boardService: BoardService, private cardService: CardService) { }

 

  ngOnInit(): void {
    this.boardService.getAllBoards().subscribe(boards => {
      this.boards = boards;
    });
  }

  onBoardSelect(target: any): void {
    const boardId = +(target.value);
    if (!isNaN(boardId)) {
      this.boardService.getBoardById(boardId).subscribe(board => {
        this.selectedBoard = board;
      });
    }
  }

  getPriorityLabel(priority: CardPriority): string {
    switch (priority) {
      case CardPriority.Low:
        return 'Low';
      case CardPriority.Medium:
        return 'Medium';
      case CardPriority.High:
        return 'High';
      default:
        return '';
    }
  }


   

}
