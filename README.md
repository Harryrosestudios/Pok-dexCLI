# Pokédex CLI Application

A feature-rich command-line interface for exploring Pokémon data using the PokéAPI. Built with C# and .NET, this application demonstrates clean architecture, API integration, and polished console user experience.

## 🎮 Overview

This **Pokédex CLI** provides instant access to comprehensive Pokémon, item, and move data through an intuitive console interface. The application showcases **modern C# development practices**, **RESTful API consumption**, and **user-centered design** in a terminal environment.

## ✨ Features

### Core Functionality
- **Pokémon Search**: Lookup by name or Pokédex ID with detailed stats, types, and physical attributes
- **Item Database**: Search game items with cost, effects, and descriptions
- **Move Information**: Complete move data including power, accuracy, PP, type, and damage class
- **Flexible Input**: Accepts various name formats and handles case-insensitive searches

### User Experience
- **Colorful Interface**: Color-coded menus and data display for enhanced readability
- **ASCII Art Borders**: Professional-looking data presentation with formatted tables
- **Visual Stat Bars**: Graphical representation of Pokémon base stats with color coding
- **Error Handling**: Graceful handling of invalid inputs and network errors
- **Responsive Design**: Clear navigation and "press any key to continue" flow

## 🛠️ Technology Stack

- **C# 11** with .NET 6+
- **RestSharp** - HTTP client library for API requests
- **Newtonsoft.Json** - JSON serialization/deserialization
- **PokéAPI** - RESTful Pokémon data API
- **Async/Await** - Asynchronous programming patterns

## 🏗️ Architecture

The application follows **clean architecture principles** with clear separation of concerns:

```
SimplePokedex/
├── Program.cs           # Main entry point and UI logic
├── Services/
│   └── PokeApiService.cs    # API service layer
├── Models/
│   └── ApiModels.cs         # Data transfer objects
└── Helpers/
    └── DisplayHelper.cs     # UI formatting and display logic
```

### Key Design Patterns
- **Service Layer Pattern**: Encapsulated API logic in `PokeApiService`
- **Static Helper Classes**: Reusable display formatting methods
- **Data Transfer Objects**: Clean model classes with JSON attributes
- **Separation of Concerns**: UI, business logic, and data access clearly separated

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- Internet connection for API access

### Installation & Setup
```bash
# Clone the repository
git clone 
cd SimplePokedex

# Restore NuGet packages
dotnet restore

# Build the application
dotnet build

# Run the application
dotnet run
```

### Usage Examples
```
WELCOME TO POKEDEX CLI
Search Pokemon, Items, and Moves

Please select what you want to search:
 1. Pokemon
 2. Item  
 3. Move
 4. Exit

Enter your choice (1-4): 1
Enter Pokemon name or ID: pikachu

╔════════════════════════════════════════╗
║ POKEMON: PIKACHU                       ║
║ #0025                                  ║
╚════════════════════════════════════════╝

Height: 0.4m
Weight: 6.0kg
Types: Electric

Base Stats:
 HP                    35 [███████░░░░░░░░░░░░░]
 Attack                55 [███████████░░░░░░░░░]
 Defense               40 [████████░░░░░░░░░░░░]
```

## 🎯 Key Skills Demonstrated

### Technical Proficiency
- **API Integration**: RESTful service consumption with proper error handling
- **Async Programming**: Efficient use of async/await patterns
- **JSON Processing**: Complex object deserialization and data mapping
- **Exception Handling**: Robust error management and user feedback

### Software Engineering
- **Clean Code**: Well-structured, maintainable codebase
- **SOLID Principles**: Single responsibility and dependency inversion
- **User Experience**: Intuitive interface design and user flow
- **Performance**: Efficient HTTP client configuration and timeout handling

### .NET Ecosystem
- **NuGet Package Management**: RestSharp and Newtonsoft.Json integration
- **Console Applications**: Advanced terminal UI with colors and formatting
- **Modern C#**: Latest language features and best practices

## 📊 Application Highlights

- **10-second timeout** configuration for reliable API requests
- **Color-coded stat visualization** with dynamic bar charts
- **Intelligent text wrapping** for long descriptions
- **Case-insensitive search** with automatic formatting
- **Comprehensive error messaging** for better user experience

## 🔮 Future Enhancements

- [ ] **Caching System**: Local data storage for faster repeated searches
- [ ] **Batch Operations**: Search multiple Pokémon simultaneously
- [ ] **Export Functionality**: Save results to JSON/CSV files
- [ ] **Team Builder**: Create and manage Pokémon teams
- [ ] **Configuration File**: Customizable colors and display options
- [ ] **Unit Tests**: Comprehensive test coverage for all components

## 🌟 Portfolio Value

This project demonstrates **full-stack thinking** in a console environment, showcasing:
- **API-first development** approach
- **User-centric design** even in CLI applications
- **Professional code organization** and documentation
- **Real-world problem solving** with external data sources

**Built with**: C# | .NET 6 | RestSharp | PokéAPI | **Focus**: Clean Architecture & API Integration
