import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IBoard } from "src/app/model/board";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class BoardService {

    constructor(private http: HttpClient) { }

    getAllBoards(): Observable<IBoard[]> {
        return this.http.get<IBoard[]>(`${environment.apiURL}/Board/FetchAllBoards`);
    }


    getBoardById(id: number): Observable<IBoard> {
        return this.http.get<IBoard>(`${environment.apiURL}/Board/FetchBoard${id}`);
    }
}