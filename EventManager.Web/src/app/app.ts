import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EventService, Evento } from './services/event.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class AppComponent implements OnInit {
  private eventService = inject(EventService);
  events: Evento[] = [];

  // 👇 AQUI ESTÁ A VARIÁVEL QUE FALTAVA
  modoEdicao = false;

  novoEvento: Evento = {
    title: '',
    description: '',
    date: '',
    location: ''
  };

  ngOnInit() {
    this.carregarEventos();
  }

  carregarEventos() {
    this.eventService.getEvents().subscribe({
      next: (dados) => this.events = dados,
      error: (erro) => console.error('Erro:', erro)
    });
  }

  salvar() {
    if (this.modoEdicao) {
      // MODO EDIÇÃO (PUT)
      this.eventService.updateEvent(this.novoEvento).subscribe({
        next: () => {
          alert('Evento atualizado!');
          this.limparFormulario();
          this.carregarEventos();
        },
        error: (erro) => alert('Erro ao atualizar: ' + erro.message)
      });
    } else {
      // MODO CRIAÇÃO (POST)
      this.eventService.createEvent(this.novoEvento).subscribe({
        next: () => {
          alert('Evento criado!');
          this.limparFormulario();
          this.carregarEventos();
        },
        error: (erro) => alert('Erro ao criar: ' + erro.message)
      });
    }
  }

  preencherParaEdicao(evento: Evento) {
    this.novoEvento = { ...evento };
    this.modoEdicao = true;
  }

  excluir(id?: string) {
    if (!id) return;
    if (confirm('Tem certeza?')) {
      this.eventService.deleteEvent(id).subscribe(() => this.carregarEventos());
    }
  }

  limparFormulario() {
    this.novoEvento = { title: '', description: '', date: '', location: '' };
    this.modoEdicao = false;
  }
}
