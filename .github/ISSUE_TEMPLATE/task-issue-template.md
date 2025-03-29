---
name: Task Issue Template
about: Template padrão para criação de issues relacionadas a tarefas técnicas ou desenvolvimento
  de novas funcionalidades.
title: "[TASK]"
labels: enhancement
assignees: ''

---

## 📌 Descrição / Contexto  
> **Objetivo geral da tarefa**  
> Explique o problema ou necessidade que essa issue busca resolver.  
> Forneça contexto técnico, regulatório ou de negócio, se necessário.

**Exemplo:**  
Precisamos criar um sistema de inventário funcional para o nosso jogo 2D de ação. Isso permitirá ao jogador coletar, equipar e usar itens, enriquecendo a experiência e abrindo espaço para mecânicas de progressão.

---

## 👤 User Story  
> Use o formato:  
> *Como [perfil de usuário]*, quero [ação desejada], para que [benefício de negócio]*.

**Exemplo:**  
Como desenvolvedor de gameplay, quero um sistema de inventário reutilizável, para que possamos testar e iterar rapidamente mecânicas relacionadas a itens e equipamentos.

---

## 📋 Resultado Esperado  
> Quais artefatos, scripts, relatórios ou funcionalidades devem estar prontos ao final da tarefa?

**Exemplo:**  
- Prefab de inventário funcional com UI básica  
- Script modular para adicionar/remover itens  
- Integração com sistema de coleta no jogo  
- Documentação de uso para o time

---

## ⚙️ Detalhes Técnicos / Escopo  
> Detalhar o que deve ser feito tecnicamente.  
> Pode usar subtópicos e bullets.

**Exemplo:**  
1. Criar classe `InventoryManager` com lógica de slots e stack  
2. Implementar `Item` como ScriptableObject com atributos  
3. Conectar coleta de itens ao sistema de inventário  
4. Criar uma interface visual simples (UI) para exibição  
5. Garantir compatibilidade com diferentes resoluções  
6. Escrever testes unitários para adição e remoção de itens  

---

## 📌 Checklist de Tarefas  
> Lista de subtarefas que podem ser marcadas conforme concluídas.

**Exemplo:**  
- [ ] Criar ScriptableObject base para itens  
- [ ] Implementar sistema de slots no inventário  
- [ ] Desenvolver UI de inventário com Unity UI Toolkit  
- [ ] Conectar sistema de coleta ao inventário  
- [ ] Testar interações básicas (adicionar, remover, usar item)  
- [ ] Documentar estrutura no Confluence  
- [ ] Submeter PR com revisores  

---

## ✅ Critérios de Aceite  
> O que precisa estar funcionando ou disponível para que a issue seja aceita?

**Exemplo:**  
- Sistema de inventário funcional em tempo de execução  
- Nenhum erro ao adicionar/remover itens  
- Interface intuitiva e responsiva  
- Cobertura mínima de testes automatizados  
- Código revisado e mergeado

---

## 📦 Definição de Done  
> Estado esperado da tarefa ao ser encerrada.

**Exemplo:**  
- Código do inventário mergeado na branch `develop`  
- Demo funcional no build de desenvolvimento  
- Documentação de uso adicionada ao README do projeto  
- Testes automatizados passando no CI  

---

## 🔍 Observações Adicionais  
> Notas soltas, sugestões, decisões, ou informações úteis que não se encaixam nas outras seções.

**Exemplo:**  
- Idealmente o sistema deve permitir fácil extensão para multiplayer  
- Pensar na possibilidade de usar eventos para comunicação entre sistemas  
- A interface pode ser refinada em um sprint futuro  

---

## 🔗 Referências / Links Úteis (opcional)  
> Links para documentação externa, APIs, RFCs, páginas de referência, etc.

**Exemplo:**  
- [Unity UI Toolkit Docs](https://docs.unity3d.com/Manual/UIElements.html)  
- [ScriptableObject Pattern](https://www.youtube.com/watch?v=raQ3iHhE_Kk)  

---

## ⚠️ Riscos ou Limitações (opcional)  
> Quais fatores podem impactar o andamento ou sucesso dessa tarefa?

**Exemplo:**  
- Mudanças na arquitetura do projeto podem exigir retrabalho  
- Falta de padronização na definição dos itens  
- Complexidade de integração com sistema de salvamento
