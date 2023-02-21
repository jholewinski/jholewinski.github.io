+++
title = "CSE 3902: Sprint 3"
template = "class-page.html"
+++

Functionality Check-In: Mar 5 at 11:59pm

Due: Mar 19 at 11:59pm

# Objectives

- Continue to develop more core features of your 2D game framework.
- Implement collision handling for all types of collisions that can occur,
  causing state transitions or position changes when necessary.
- Instead of placing all objects on screen at once, create the individual
  "rooms" (or "screens" if you prefer) of the dungeon each with its own subset
  of objects. Store this information in a file (recommendation: csv or xml) and
  write code to initialize objects based on the file's contents.
- Create an artificial level that contains an instance of Link and all types of
  objects that are found in your first dungeon. For testing purposes, include a
  way for the user to quickly switch to any room in the dungeon instead of
  having to walk through multiple rooms to reach it.

Note: you should base the behavior of your game's objects off of the original
game in order to complete a comparable amount of work to that of previous teams
in this course, but you do not need to replicate everything with 100% accuracy.
You should document any major deviations to avoid it getting marked as a bug.
Also note that you do not need a fully finished game by the end of this sprint,
some elements such as sound, smooth camera transitions, etc. are not required
until the next sprint.

## Controls and UI

- Use the arrow keys and WASD for player movement
- This sprint is a good time to create a gamepad class, but this is not a hard
  requirement
- Continue to allow the use of different items via numeric keys 1, 2, 3, etc.
- Recommendation: have all of the item pickups in the starting room, or start
  the player with an infinite amount of each item
- Use the mouse controller as a way to transition between rooms. How you do this
  is entirely up to you, but consider doing so by clicking on a map.
  Alternatively, treat the rooms as in an ordered collection, with left click
  moving to the previous room and right click moving to the next room.

{{ image(src="sprint3.png") }}

# Work Expectations

- Planning
  - Enter start and end dates for the sprint.
  - Create product backlog items and tasks for the required features of the
    sprint.
  - Associate all of these work items and tasks with the curernt sprint.
- Software developmentand task tracking
  - Implement the features described in the sprint description.
  - Each team member should implement the tasks assigned to them.
  - When you start work on a task, drag the task to In-Progress on the board.
  - If you did not finish the task that day, reduce the remaining work time
    estimate for the task.
  - If you finished the task, drag it to Done and make sure its remaining work
    time is zero.
  - You should place a high priority on the readability and simplicity of your
    code during the first half of the sprint.
  - When refactoring, place a higher priority on the maintainability of the
    code.
  - Try to finish early, given a three week period for a sprint, here are some
    recommended deadlines:
    - First day of sprint - finish putting tasks up on the board
    - End of second week - finish all of the functionality for the sprint ;
      complete one set of code reviews
    - Middle of third week - finish all code refactoring for the sprint ;
      complete second set of code reviews
    - End of the third week - complete remaining documentation and adminstrative
      tasks (described below)
- Other processes and tasks
  - README document
    - Write up a document with useful information on your project. This might
      include: program controls, descriptions of known bugs that program has,
      and details of any tools or processes your team used that aren't
      explicitly required (for example, calculating and using Code Metrics as
      part of your design process)
  - Use tools to improve your code and/or create documentation about your
    codebase - do at least one of the following:
    - Calculate your code metrics within Visual Studio under the Analyze menu.
      Generate and record this values at least once a week, consider putting
      them in a spreadsheet and making graphs using the data.
    - Use the .NET code analyzers (Roslyn) with rules for
      [code quality analysis](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/overview#code-quality-analysis).
      Document any errors or warnings that you get, then on-by-one fix them or
      set them as supressed with an explanation in your documentation on why you
      supressed that particular warning/error.
  - Code Reviews
    - Each member of the team should review at least one class and have at least
      one of their classes reviewed, with a focus on code readability
    - Each member of the team should review at least one class and have at least
      one of their classes reviewed, with a focus on code maintainability
    - More detailed guidelines on a code review process can be found below
  - Sprint reflection
    - Near the end of the sprint, write up a brief report on how your team
      performed this sprint, using the burndown chart from the board as the
      basis for discussion.
    - Feel free to also discuss your processes as a whole. Were any changes your
      made this sprint constructive or detrimental? Do you have any plans for
      doing things differently next sprint?

## On code reviews

The best way to fulill the requirement of documenting reviewing of code within
your team is by doing
[pull requests](https://docs.github.com/en/github/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests).
Alternatively, you can write up code reviews in plaintext documents to be
submitted with the project. In the root folder of the project, add a folder to
store code reviews. You can add plaintext files to the project in this folder by
going to the Project menu, add new item, and select text file under the general
option.

In the plaintext file for a readability review, include the following
information:

- Author of the code review
- Date of the code review
- Sprint number
- Name of the .cs file being reviewed
- Author of the .cs file being reviewed
-  Number of minutes taken to complete the review
- Specific comments on what is readable and what is not

In the plaintext file for a code quality review, include the following
information:

- Author of the code review
- Date of the code review
- Sprint number
- Name of the .cs file being reviewed
- Author of the .cs file being reviewed
- Specific comments on code quality
- A hypothetical change to make to the game related to file being reviewed and how the current implementation could or could not easily support that change

# Functionality check-in

One member of your team should follow the build->clean and project folder
zipping process from Sprint0 and turn in your project on Carmen on the
appropriate assignment page. The purpose of this submission is similar to the
"early bonus" from Sprint0 - incentive for students to not delay in getting
their portion of the project done before the last few days of the sprint. These
submissions will be briefly tested (5-10 minutes), and if a submission appears
to have at least 75% of the functional requirements for the sprint the team will
be deemed to have passed the functional check-in. Passing the functional
check-in will be worth about 5%, or half a letter grade, on the grading of the
sprint as a whole. Feedback on these submissions will be limited.

# Project Submission

One member of your team should follow the build->clean and project folder
zipping process from Sprint0 and turn in your project on Carmen on the
appropriate assignment page. If they aren't included in the zip file, also add
your README and sprint reflection documents (and any other project management
documents you made). After the sprint is over, everyone should fill out a peer
review form rating the work of everyone on your team, yourself included, for
that sprint and turn in the file on Carmen on the assignment page for the peer
review. Additionally, at least one member of your team will need to arrange a
meeting with your grader to review your work (at minimum the contents of your
board, but you may review more). Exceptions granted if you provide this
documentation in another form, ex: screenshots of tasks board or direct log-in
access to your taskboard

Lateness: your grader is permitted to evaluate submissions turned in 1-2 days
late, but expect it to come with a 5%, or half a letter grade, penalty.

# Peer reviews

The peer reviews are one of the main ways we get information about how your team
is doing, so take your time to fill them out thoroughly and honestly. In cases
where peer reviews provide conflicting information, either in inconsistent
scores for a team member or inconsistency in scores and the overall
functionality of the project, your team might be asked to meet with the
instructor to review your code commit logs to obtain more detailed information
on each team member's contribution.

# Grading

Each sprint you'll receive feedback on how your team is progressing. Your grader
will review your work and provide comments on

- your documentation (task tracking, code reviews, code metrics/analysis)
- code functionality (has your team implemented enough work for its size and how
  buggy is it)
- (workload permitting also comments on code quality)

The team will get a rough letter grade for each sprint (within feedback, not as
a score within the Carmen gradebook),

- A - exceptional work, goes beyond stated expectations
- B - good to average work
- C - needs improvement
- D - needs significant improvement

Your instructor will review your work (frequency TBD, likely to be every other
sprint) and provide comments on

- code quality

Code quality will also play a role in determining numeric project scores at the
end of the semester. Assume around 30-40% of the project scores are based on
meeting high quality code standards. You should refactor your code to eliminate
any major code quality problems cited by your instructor and grader. Minor
issues may be excused but only after discussing the details with your
instructor.
