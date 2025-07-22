# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose
This RimWorld mod enhances the ideologies and rituals within the game by introducing new concepts and systems. The mod focuses on expanding the depth of social interactions, belief systems, and commemorative rituals in a colony's daily life. This enhancement aims to enrich player experience by offering more nuanced storytelling and emergent gameplay scenarios.

## Key Features and Systems

- **Expanded Ritual System**: Adds new roles and stages to existing rituals. For example, the `RitualRoleColonistGladiator` and `RitualRoleNonSlaveColonist` classes introduce new participant roles.
- **Thought and Memory Modifications**: Implements new thoughts that influence mood based on population levels and trading activity, represented by classes like `Thought_Situational_Precept_PopulationHigh` and `Thought_Situational_Precept_Trading`.
- **Death and Memorialization**: Enhances how colonist deaths are perceived and commemorated, as seen in `PreceptDefOfDeath` and `ThoughtDefOfDeath` classes.
- **Historical Context**: Captures colony history events, including colonist deaths, using the `History` class.

## Coding Patterns and Conventions

- **Modular Design**: Functions are divided among specific, purpose-driven classes (e.g., `ThoughtWorker` classes for handling mood thoughts) to promote maintainability and clarity.
- **Use of Interfaces**: Interfaces like `IExposable` and `IPreceptCompDescriptionArgs` ensure consistent behavior and improve scalability.
- **Static Classes for Patching**: Classes such as `HistoryPatch` and `MemoryPatch` are utilized for specific game memory and historical patches.
- **Consistent Naming Conventions**: Classes and methods use clear and descriptive naming, following PascalCase and camelCase conventions.

## XML Integration

While the current extracted summary does not specify XML content, remember that XML definitions in RimWorld mods typically define object properties, names, and in-game behavior additional to C#. Copilot should consider helping by suggesting typical XML structures for defining new game components like Thoughts, Precepts, and Rites.

## Harmony Patching

Harmony is used to inject custom behavior into existing game code without altering the original assembly:

- **Patch Structure**: Each patch is encapsulated within its own static class, such as `MemoryPatch` and `TradedDealPatch`.
- **Method Prefix/Postfix**: When creating Harmony patches, distinct methods can act as either prefixes or postfixes to execute code before or after the original method.
- **Debugging Practices**: Use logging to verify the success of patches within the methods.

## Suggestions for Copilot

- **Code Completion**: Assist with completing partially written method implementations, especially those dealing with complex logic or interaction between game components.
- **Refactoring Proposals**: Recommend breaking down large methods into smaller, focused methods to improve readability and reusability.
- **Best Practice Enforcement**: Suggest implementations that comply with existing patterns, such as consistent use of Harmony patches.
- **XML File Generation**: Propose template XML for defining new game assets, easing the integration process for mod content.

Please ensure any generated code respects game modding policies and remains open-source-friendly. Use this instruction file to guide automated suggestions toward producing efficient, cohesive, and maintainable modding code.
