# 🧟 Dead.ToString()

**RPG de sobrevivência em um apocalipse zumbi, desenvolvido em C# e executado diretamente no Console.**

> 🚧 **WIP — Projeto em desenvolvimento!**
>
> O jogo ainda está passando pelas últimas etapas de desenvolvimento. Algumas funcionalidades podem sofrer alterações e a versão atual ainda não representa a versão final.

## 📖 História

O mundo como conhecíamos acabou... Mortos-vivos tomaram as ruas da cidade, devorando todas as pessoas que encontravam!

Algumas pessoas conseguiram escapar e se esconderam em abrigos improvisados, mas os recursos são escassos e as ruas são perigosas...

E você é uma dessas pessoas. Você sobreviveu até aqui, porém, mais do que sobreviver, você quer descobrir o que causou tudo isso e como resolver!

Busque recursos, ajude outros sobreviventes, encontre respostas e, claro, sobreviva! :)

## 🎮 Sobre o projeto

Dead.ToString() é um jogo de RPG de sobrevivência desenvolvido em **C#**, com execução em Console e sem utilização de APIs externas.

O projeto foi desenvolvido com o objetivo de praticar e aprofundar conhecimentos em programação orientada a objetos (POO), aplicando conceitos de organização de código, criação de classes, relacionamento entre objetos e separação de responsabilidades.

### ⚙️ Funcionalidades

- Exploração de diferentes locais e ambientes.
- Sistema de combate por turnos contra zumbis.
- Inventário com capacidade limitada.
- Coleta, inspeção, utilização e descarte de itens.
- Equipamento e gerenciamento de armas e munições.
- Interação e diálogos com NPCs (personagens não jogáveis).
- Sistema de missões e recompensas.
- Navegação entre locais e salas.
- Sistema de vida, dano, defesa e atributos do jogador.
- Elementos aleatórios durante a exploração.

## 🛠️ Tecnologias utilizadas

- **C#** — Linguagem de programação.
- **.NET 10** — Plataforma utilizada para desenvolvimento e execução.
- **Console Application** — Interface de interação com o jogador.
- **Visual Studio / Visual Studio Code** — Ambiente de desenvolvimento.

Não são utilizadas APIs externas, bancos de dados ou frameworks adicionais.

## 📚 Conceitos aplicados

O desenvolvimento do projeto tem como foco a prática de Programação Orientada a Objetos (POO), incluindo:

- **Classes e objetos:** representação dos elementos do jogo, como jogador, zumbis, NPCs, armas e itens.
- **Encapsulamento:** organização e controle do acesso aos atributos e métodos das classes.
- **Herança:** reutilização de características e comportamentos entre classes relacionadas.
- **Composição:** relacionamento entre diferentes objetos para construir os sistemas do jogo.
- **Enums:** definição de conjuntos de valores para categorias, tipos de itens, armas, munições e opções de menus.
- **Collections:** utilização de listas (`List<T>`) para gerenciamento de itens, personagens e locais.
- **Métodos e construtores:** organização das operações e inicialização dos objetos.
- **Separação de responsabilidades:** divisão das funcionalidades em classes e arquivos específicos.

## 📁 Organização do projeto

O código está dividido em pastas de acordo com as responsabilidades de cada conjunto de classes:

| Pasta | Responsabilidade |
|---|---|
| `Enums/` | Enumerações utilizadas pelo jogo. |
| `Itens/` | Classes de itens, armas, munições, consumíveis e inventário. |
| `Seres/` | Classes relacionadas ao jogador, NPCs, pessoas e zumbis. |
| `Local/` | Representação dos locais, salas, portas e mapa. |
| `Jogo/` | Gerenciamento do jogo e seus sistemas. |
| `Jogo/Dados/` | Criação e configuração dos elementos utilizados no jogo. |
| `Jogo/Interface/` | Menus e exibição de informações no Console. |
| `Jogo/Sistemas/` | Sistemas de exploração, navegação, missões e inventário. |
| `Jogo/Validacao/` | Validação das entradas fornecidas pelo jogador. |

## 💻 Requisitos

Para executar o projeto, é necessário ter:

- Windows, Linux ou macOS.
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- Um terminal ou ambiente de desenvolvimento compatível com C#.

Não é necessário configurar banco de dados, instalar dependências externas ou utilizar chaves de API.

## ▶️ Como executar

1. Clone este repositório:

   ```bash
   git clone https://github.com/SEU-USUARIO/SEU-REPOSITORIO.git
   ```

2. Acesse a pasta do projeto:

   ```bash
   cd Dead.ToString_WIP
   ```

3. Execute o projeto:

   ```bash
   dotnet run
   ```

O próprio .NET realizará a restauração das dependências necessárias e iniciará a aplicação no Console.

## 🎯 Objetivo

Este projeto foi desenvolvido como uma oportunidade de aprendizado e aplicação prática dos conceitos de C# e Programação Orientada a Objetos.

Além de desenvolver um jogo funcional, a proposta é aprimorar habilidades de programação, organização de código, modelagem de classes e construção de sistemas utilizando os recursos da linguagem.

---

**Desenvolvido com C# e muito aprendizado! 🧟**
