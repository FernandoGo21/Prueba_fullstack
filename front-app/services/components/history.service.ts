import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import settings_json from '../../configuration/settings.json';
import { ApiModel, FactModel } from '../../models/api.model';

@Injectable({
    providedIn: 'root'
})
export class HistoryService{
    api_base:string = settings_json.APIS.ApiBase;
    api_history:string = settings_json.APIS.ApiHistory;

    constructor(private httpClient: HttpClient) {}

    public getHistorySearchs(page: number = 1, pageSize: number = 10): Observable<any> {
      let params = new HttpParams()
        .set('page', page.toString())
        .set('pageSize', pageSize.toString());
      return this.httpClient.get<any>(`${this.api_base}${this.api_history}`, { params });
    }
}
