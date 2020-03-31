using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUni_Course_Planning
{
    class SoftUniCoursePlanning
    {
        static void Main()
        {
            //            You are tasked to help with the planning of the next Technology Fundamentals course by keeping track of the lessons, that are going to be included in the course, as well as all the exercises for the lessons. 
            //On the first line you will receive the initial schedule of the lessons and the exercises that are going to be a part of the next course, separated by comma and space ", ".But before the course starts, some changes should be made.Until you receive "course start" you will be given some commands to modify the course schedule.The possible commands are: 
            //Add:{ lessonTitle} – add the lesson to the end of the schedule, if it does not exist.
            //Insert:{ lessonTitle}:{ index} – insert the lesson to the given index, if it does not exist.
            //Remove:{ lessonTitle} – remove the lesson, if it exists.
            //Swap:{ lessonTitle}:{ lessonTitle} – change the place of the two lessons, if they exist.
            //Exercise:{ lessonTitle} – add Exercise in the schedule right after the lesson index, if the lesson exists and there is no exercise already, in the following format "{lessonTitle}-Exercise".If the lesson doesn`t exist, add the lesson in the end of the course schedule, followed by the Exercise.
            //Each time you Swap or Remove a lesson, you should do the same with the Exercises, if there are any, which follow the lessons.

            List<string> courses = Console.ReadLine().Split(", ").ToList();
            string line = Console.ReadLine();

            while (line != "course start")
            {
                List<string> command = line.Split(':').ToList();
                string action = command[0];
                string title = command[1];
                int titleIndex = courses.IndexOf(title);

                switch (action)
                {
                    case "Add":
                        if (titleIndex < 0)
                        {
                            AddLesson(courses, title);
                        }

                        break;

                    case "Insert":
                        int index = int.Parse(command[2]);

                        if (titleIndex < 0 &&
                            index >= 0 &&
                            index <= courses.Count - 1)
                        {
                            courses.Insert(index, title);
                        }
                        break;

                    case "Remove":
                        if (titleIndex >= 0)
                        {
                            if (CheckIfExerciseExistAfterTitle(courses, title))
                            {
                                courses.RemoveRange(titleIndex, 2);
                            }
                            else
                            {
                                courses.RemoveAt(titleIndex);
                            }
                        }
                        break;

                    case "Swap":
                        string firstTitle = title;
                        string secondTitle = command[2];
                        int firstTitleIndex = courses.IndexOf(firstTitle);
                        int secondTitleIndex = courses.IndexOf(secondTitle);

                        if (firstTitleIndex >= 0 && secondTitleIndex >= 0)
                        {
                            SwapItems(courses, firstTitle, secondTitle);

                            if (CheckIfExerciseExistAfterTitle(courses, firstTitle) &&
                                CheckIfExerciseExistAfterTitle(courses, secondTitle))
                            {
                                SwapItems(courses, courses[firstTitleIndex + 1], courses[secondTitleIndex + 1]);
                            }
                            else if (CheckIfExerciseExistAfterTitle(courses, firstTitle) &&
                                     !CheckIfExerciseExistAfterTitle(courses, secondTitle))
                            {

                                List<string> excerciseOfLesson = courses[firstTitleIndex + 1].Split('-').ToList();


                                AddExerciseAfterExistingTitle(courses, secondTitleIndex, excerciseOfLesson);

                                RemoveDuplicateExercise(courses, excerciseOfLesson);

                            }
                            else if (!CheckIfExerciseExistAfterTitle(courses, firstTitle) &&
                                     CheckIfExerciseExistAfterTitle(courses, secondTitle))
                            {
                                List<string> excerciseOfLesson = courses[secondTitleIndex + 1].Split('-').ToList();

                                AddExerciseAfterExistingTitle(courses, firstTitleIndex, excerciseOfLesson);

                                RemoveDuplicateExercise(courses, excerciseOfLesson);

                            }

                        }

                        break;
                    case "Exercise":

                        if (titleIndex < 0)
                        {
                            AddLesson(courses, title);

                            AddExercise(courses, title, courses.Count);
                        }
                        else if (titleIndex >= 0 &&
                            !CheckIfExerciseExistAfterTitle(courses, title))
                        {

                            AddExercise(courses, title, titleIndex + 1);


                        }

                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }

            for (int i = 1; i <= courses.Count; i++)
            {
                Console.WriteLine($"{i}.{courses[i - 1]}");

            }
        }

        private static void RemoveDuplicateExercise(List<string> courses, List<string> excerciseOfLesson)
        {
            for (int i = 1; i <= courses.Count - 1; i++)
            {
                if (courses[i] == $"{excerciseOfLesson[0]}-{excerciseOfLesson[1]}" &&
                    courses[i - 1] != excerciseOfLesson[0])
                {
                    courses.RemoveAt(i);
                    break;
                }
            }
        }

        private static void AddExerciseAfterExistingTitle(List<string> courses, int secondTitleIndex, List<string> excerciseOfLesson)
        {
            if (secondTitleIndex < courses.Count - 1)
            {
                courses.Insert(secondTitleIndex + 1, $"{excerciseOfLesson[0]}-{excerciseOfLesson[1]}");
            }
            else
            {
                courses.Add($"{excerciseOfLesson[0]}-{excerciseOfLesson[1]}");
            }
        }

        private static int GiveLessonIndex(List<string> courses, string title)
        {
            int index = courses.IndexOf(title);


            return index;
        }

        private static void AddExercise(List<string> courses, string title, int index)
        {
            courses.Insert(index, $"{title}-Exercise");
        }

        private static bool CheckIfExerciseExistAfterTitle(List<string> courses, string title)
        {
            bool exist = false;
            string name = $"{title}-Exercise";

            if (courses.Contains(name))
            {
                exist = true;
            }

            return exist;
        }


        private static void SwapItems(List<string> courses, string firstTitle, string secondTitle)
        {
            int firstTitleIndex = courses.IndexOf(firstTitle);
            int secondTitleIndex = courses.IndexOf(secondTitle);


            courses[firstTitleIndex] = secondTitle;
            courses[secondTitleIndex] = firstTitle;

        }

        private static void AddLesson(List<string> courses, string title)
        {

            courses.Add(title);

        }
    }
}
