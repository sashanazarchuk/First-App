import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ICard } from "src/app/model/card";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn: 'root'
})
export class CardService {

    constructor(private http: HttpClient) { }

    editCard(cardId:number, data: any): Observable<ICard[]> {
        return this.http.patch<ICard[]>(`${environment.apiURL}/Card/EditItem/${cardId}`, data);
    }
 
    getCardById(cardId:number): Observable<ICard>{
        return this.http.get<ICard>(`${environment.apiURL}/Card/FetchCard/${cardId}`);
    }

    createCard(card:ICard): Observable<ICard>{
        return this.http.post<ICard>(`${environment.apiURL}/Card/CreateCard`, card);
    }
}