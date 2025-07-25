import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import settings_json from '../../configuration/settings.json';
import { ApiModel, FactModel, QueryModel } from '../../models/api.model';

@Injectable({
    providedIn: 'root'
})
export class ApiService{
    api_base:string = settings_json.APIS.ApiBase;
    api_fact:string = settings_json.APIS.ApiFact;
    api_gif:string = settings_json.APIS.ApiGif;
    api_other_gif:string = settings_json.APIS.ApiOtherGif;

    constructor(private httpClient: HttpClient) {}

    public getFact():Observable<any>{
        return this.httpClient.get<any>(`${this.api_base}${this.api_fact}`).pipe(map((response:any)=>{
          return response;
        }));
    }
    public getGif(event:FactModel):Observable<ApiModel>{
      const params = new HttpParams().set('fact', event.fact.toString())
      return this.httpClient.get<any>(`${this.api_base}${this.api_gif}`,{params}).pipe(map((response:any)=>{
        return response;
      }));
    }
    public getOtherGif(event:QueryModel):Observable<ApiModel>{
      const params = new HttpParams().set('query', event.query.toString())
      return this.httpClient.get<any>(`${this.api_base}${this.api_other_gif}`,{params}).pipe(map((response:any)=>{
        return response;
      }));
    }

}
