create table Authentications(
userid numeric(3) primary key,
username varchar(30),
password varchar(30)
)

create table Users( 
userid numeric(3) primary key foreign key references authentications(userid),
firstname varchar(30),
lastname varchar(30),
email varchar(30),
weight numeric(5,2),
height numeric(5,2),
startdate datetime,
goalweight numeric(5,2)

)

create table Workouts(
workoutid numeric(3) primary key,
workoutname varchar(50),
workouttype varchar(10),
bodypart varchar(30)
)

create table Exercises(
exerciseid numeric(3) primary key,
dayoftheweek varchar(15), 
startweight numeric(5,2),
goalweight numeric(5,2),
startset int,
goalset int,
startrep int,
goalrep int,
maxonerep numeric(5,2),
workoutid numeric(3) foreign key references Workouts(workoutid)
)

create table UserExercises(
userid numeric(3) foreign key references users(userid),
exerciseid numeric(3) foreign key references exercises(exerciseid),
routinestartdate datetime,
routineactive bit,

primary key (userid, exerciseid)
)

create table Progress(
date datetime,
userid numeric(3) foreign key references users(userid),
exerciseid numeric(3) foreign key references exercises(exerciseid),
setnumber int,
workingweight numeric (5,2),
reps int,
rpe int,

primary key (date, userid, exerciseid)

)