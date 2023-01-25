+++
title = "CSE 3902: Sprint 1"
template = "class-page.html"
+++

# Objectives

- Familiarize yourself with Github or AzureDevOps for project management and
  source code/version control.
- Familiarize yourself with Requirements/Use Cases for your 2D game project.
- Organize and coordinate with your team.

For the project in this course, you will be required to use task tracking
software to coordinate with your teammates and document your progress on the
project. Ideally, you will summarize your work at the end of each sprint by
creating a burndown chart. Examples: using ZenHub and in AzureDevOps. You will
also be required to use source/version control for your code. Your team may use
either GitHub or AzureDevOps. There are a few factors that may influence your
teams' decision. First and foremost, AzureDevOps supports two different flavors
of version control, one like subversion (which was taught in Software II) and
one like Git whereas GitHub only supports Git. At some point in your undergrad
education you should learn Git, but it takes longer to learn and we've limited
time to spend on it in class. Second, AzureDevOps is limited to 5 free accounts
on a project. Lastly, there's a slight difference in how much documentation I
have for each toolset, but I hope you're confident enough in your own research
skills that this doesn't sway your decision.


# Learning the tools (AzureDevOps version)

- Account and project setup (if using Azure DevOps)
  - All team members should create an account for AzureDevOps
    (https://azure.microsoft.com/en-us/services/devops/) and add a profile
    image. If you are going to use your osu name.# address for your account
    name, you are encouraged to write your username as ending in "@osu.edu"
    instead of "@buckeyemail.osu.edu". Using the second format will cause the
    project to be associated with Azure directory, which will make adding
    non-Azure connected accounts more difficult.
  - Create a New Organization, you might name it after the course number and
    current semester.
  - As a team, decide if you want to use the subversion-like source control
    (Team Foundation Version Control) or the GIT version.
  - In the organization create a new private project, naming it after your team
    or the game you are implementing. Under the advanced options choose the type
    of version control you want to use and Scrum for the Work item process.
  - Once your team is fully assembled, you'll only use one of the project, so
    one person is the De Facto "project owner". The project owner should add the
    rest of the team to their organization and project. You will need to know
    the account names of your teammates to do this. General information on how
    to add accounts can be found here.
  - The project owner will need to manage the date ranges for each Sprint in
    order for burndown charts to be made automatically.
  - The project owner should also investigate and customize other settings to
    the team's preferences. For example, by default the burndown chart "skips"
    weekends whereas you'll likely want details on those days included.
- Task tracking using a web browser
  - Each team member should add a product backlog item and assign it to Sprint 1.
  - Each team member should add a task under a product backlog item, making sure
    to include an effort amount and assign it to themselves. Note: you do not
    have to actually implement the task as part of Sprint 1. This is just to get
    you familiar with how the project tracking software works.
  - The day after each task was added, each team member should update their task
    once to indicate progress has been done on it (lower the effort amount but
    not to 0).
  - The day after each task was updated, each team member should update their
    task to completed.
  - Individual tasks using source code control within Visual Studio
    - Have one person commit a template Monogame project (or if you can confirm
      all of your team members have successfully finished Sprint 0, you may
      commit your Sprint 0 implementation). Instructions for working with TFVC
      are here and instructions for GIT are here. Note: while only one person
      does the initial commit, everyone should read these. comment, and commit
      the new code.
    - Each team member should check out the code, change a line of code or add a
      comment, and commit the new code.

# Learning the tools (GitHub version)

Github resources:

- Account creation:
  [GitHub student developer pack](https://education.github.com/pack)
- Creating a repository, making commits, making pull requests:
  [GitHub Hello World guide](https://guides.github.com/activities/hello-world/)
- [Github project boards](https://docs.github.com/en/issues/organizing-your-work-with-project-boards/managing-project-boards/about-project-boards)
- Similar to the above steps for AzureDevOps, everyone should create at least one task on the taskboard, connect to the team's repo, and commit one change to the code
- [GitHub Help Documentation](https://help.github.com/en/github)
- [Github quick reference / cheat sheet](https://github.github.com/training-kit/downloads/github-git-cheat-sheet.pdf)
- [Misc. learning materials from try.github.io/](https://try.github.io/)

# Team building

Depending on whether or not you have preselected a full team you will likely need to do most of the following during the first few days of Sprint2.

- Arrange an event (a meal, gaming, a sporting event, a movie, watching meme
  videos, any sort of activity that you have a shared interest in) and get to
  know each other better.
- Create a team name and inform your instructor so that your placeholder team
  name can be replaced.
- Work on learning your teammates' names. I expect you to know your teammates
  names before the end of the semester.
- As a group, discuss your goals for the project and policies for how your team
  will operate. Write down what everyone is willing to agree to and have
  everyone sign it. Some ideas to consider:
  - What is everyone's preferred method of contact? Will the team make use of a
    communication or teamwork application such as MSTeams, Slack, Discord,
    Trello, etc.?
  - How often and long will your team meetings outside of class be? In-person or
    online? Entirely asynchronous?
  - Everyone should strive to make an excellent project that you are proud to
    include in your work portfolio. When you have to make decisions on where to
    focus the team's efforts, what are your priorities? Some options to weigh in
    no particular order: code cleanliness, project management documentation,
    communication and team morale, robustness of runtime behavior, team member
    specialization allowing different but equally appreciated contributions, and
    breadth of features.
- As a group, discuss how you will resolve any conflicts or disagreements that
  might occur over the course of the project; write and sign what you agree on.
  - The situation most prone to spiraling out of control here centers on cases
    where one person's responsibilities are taken over by another. In some cases
    this may be reasonable, ex: a feature with little to no code 1-2 (or
    whatever your team agrees on, perhaps even up to 7) days before the end of a
    Sprint. This can lead to one person having nothing to work on, making them
    feel undervalued and less interested in contributing in the future, leading
    to more cases of late or missing work. I recommend you leave late or missing
    features for the team member they were assigned to and to implement a new
    feature that was not orignally planned to be included if you want to
    compensate.
    
# Big Picture Project Notes

Starting with Sprint2 your team will begin a semester long project developing a
2D game engine. Currently, the standard project is an implementation of a 2D
top-down adventure game, styled as the first dungeon of The Legend of Zelda
(1986) with your own custom features added at near end of the semester. Teams
may petition the instructor to implement a different 2D game, including ones
from other genres such as a 2D platformer, but this will take more effort on
planning, documentation, and communication of your project's functional
requirements. If you do not have experience playing The Legend of Zelda or other
2D top down adventure games, please look into the resources
[here](@/teaching/cse3902/game-resources.md). Aside from playing the game
itself, the most useful resources for requirements gathering are the game's user
manual and videos of gameplay footage (useful search terms being: NES legend of
zelda longplay speedrun).

You will be expected to read your teammates' code, and by the end of the project
you should be able to reimplement the entire project given enough time. However,
since you'll only be implementing a subset of the game you should start to think
about which parts you would prefer to work on and discuss that with your
teammates. Near the end of the project you'll be adding new custom features of
your choice, so if there are particular options you want to try (Sprint5 page
lists some), you should make sure to be involved in the most closely related
part of the project to ensure time and effort is spent on using abstractions and
designing for ease of maintenance of it. This discussion on interests can also
help in making sure critical features are assigned to someone with more
experience or more time available to work on the project during the busier times
of the semeseter.

# Assessment

Once your team has finished creating and tracking tasks as well as making code
commits, contact your instructor during in-class team meeting time or during
office hours to have your work checked. You may still ask to have your work for
this activity checked during Sprint2. While this assignment is not graded with a
numeric score, it is a sanity check on your usage of these project tools - be
sure to ask for help if you're unsure on whether or not you're using the tools
correctly.
