import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, finalize } from "rxjs";
import { LoaderService } from "../utils/loader.service";

@Injectable({
    providedIn: 'root'
  })
  export class LoaderInterceptorService implements HttpInterceptor {

    constructor(private loaderService: LoaderService) {}
    intercept(req: HttpRequest<any>,next: HttpHandler): Observable<HttpEvent<any>> {
        this.loaderService.showLoader();
        return next.handle(req).pipe(finalize(() => this.loaderService.hideLoader()));
    }
}
