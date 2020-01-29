# CS-Profitable-Offices
Cities Skylines profitable offices mod will help you earn more money from office zones. Latest version is v1.1

01/28/2020
    * Patch is underway for the error message that is recieved after installing the mod. 
      Error message: "Unable to load options file 'Profitable Office ModOptions.xml', file not found!". 
    
    This is happens while attempting to load an options file from disk on install init, however upon installation 
    it will not have been initialized yet. The mod still works well (file is created when game initializes), options file just needs to be created before initialization.
