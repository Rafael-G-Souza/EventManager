import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

export interface Evento {
  id?: string; // O ID é opcional porque quem cria é o Banco
  title: string;
  description?: string;
  date: string;
  location: string;
}

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5285/events';

  // Buscar todos
  getEvents() {
    return this.http.get<Evento[]>(this.apiUrl);
  }

  // 👇 NOVO: Criar um evento (POST)
  createEvent(evento: Evento) {
    return this.http.post<Evento>(this.apiUrl, evento);
  }

  deleteEvent(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  updateEvent(evento: Evento) {
    return this.http.put<Evento>(`${this.apiUrl}/${evento.id}`, evento);
  }

}

