# Expense Items API Demo C# ASP Backend

## Commands for Testing (via curl)

/**
* ! FETCHING All Exercise Data
** curl http://localhost:8080/workout_data | jq
*/


/**
* ! SAVING a NEW Exercise Data from file `payloads/workoutData.json`
** curl -X POST -H "Content-Type: application/json" -d @Payloads/workoutData.json http://localhost:8080/workout_data | jq
*/


/**
* ! SAVING a NEW Exercise Data from file `payloads/workoutData.json`
** curl -X POST -H "Content-Type: application/json" -d @Payloads/workoutData.json http://localhost:8080/workout_data | jq
*/


/**
* ! DELETE a data based on id
** curl -X DELETE -H "Accept: application/json" http://localhost:8080/workout_data/3 | jq
** curl -X DELETE -H "Accept: application/json" http://localhost:8080/workout_data/3 | jq
*/
