# InventoryMastersKinect


# Guia de Configuração do Ambiente — Inventory Masters Kinect

Este guia orienta os colaboradores sobre como configurar a máquina local para rodar o projeto **Inventory Masters Kinect** utilizando o banco de dados local **SQLite** e o **Entity Framework Core**.

---

## 1. Pré-requisitos do Ambiente

Como o SQLite roda diretamente como um arquivo dentro do projeto, não é necessário instalar nenhum servidor de banco de dados pesado (como SQL Server). No entanto, é preciso garantir que o ecossistema do .NET 6 esteja completo.

### A. Runtime do .NET 6 (Desktop / WPF)
Certifique-se de que possui a carga de trabalho de desenvolvimento desktop para .NET instalada no Visual Studio. Caso precise instalar ou atualizar os runtimes do .NET 6 via terminal, execute o seguinte comando no PowerShell como Administrador:

```powershell
winget install Microsoft.DotNet.DesktopRuntime.6
```
### B. Ferramenta Global do Entity Framework Core (`dotnet-ef`)
Para evitar conflitos de versão entre o .NET 6 do projeto e versões mais recentes do SDK instaladas em sua máquina, instale globalmente a ferramenta de linha de comando do EF Core na versão correspondente:

```powershell
dotnet tool install --global dotnet-ef --version 6.0.36
```

*(Nota: Se você já tiver uma versão mais recente instalada e encontrar erros, desinstale-a primeiro com `dotnet tool uninstall --global dotnet-ef` antes de rodar o comando acima).*

---

## 2. Primeiros Passos após o `Git Pull`
Assim que você puxar as últimas alterações da branch (que já incluem a infraestrutura do banco de dados e os pacotes NuGet configurados), siga o passo a passo abaixo para gerar o seu banco de dados local:

1. Abra a Solution (`.sln`) no **Visual Studio 2022**.
2. Abra o **Package Manager Console** (Console do Gerenciador de Pacotes):
   * Vá em: `Tools` > `NuGet Package Manager` > `Package Manager Console`
3. No topo do console, verifique se o campo **Default project** (Projeto padrão) está apontando exatamente para:
   * `InventoryMastersKinect`
4. Execute o comando para aplicar as migrações existentes e criar o banco de dados:

```powershell
Update-Database
```

## 3. Estrutura e Onde o Banco Fica Salvo
* Após a execução bem-sucedida do comando, o Entity Framework gerará o arquivo local **`inventory_masters.db`** na raiz do diretório do seu projeto executável.
* Os pacotes de inicialização nativa do driver (`SQLitePCLRaw`) já estão configurados no código do projeto, garantindo o mapeamento correto das tabelas de medição.
