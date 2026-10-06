//*****************************************************************************************************************************************************************************
//*Практическая работа №10                                                                                                                                                    *
//*Сделал Егоров Н.Н, группа 2-ИСП                                                                                                                                            *
//*Задание: поменять значения столбцов, размерность нечётная: поменять первый и средний столбец, размерность чётная: средние два столбца поменять с первым и последним.       *
//*****************************************************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №10";//задаёт значение в заголовок консоли

            bool ExitProgram = false;
            Random rnd = new Random();
            while (true)
            {
                try
                {
                    int NumberMatrix = 0;
                    Console.Write("Введите размерность квадратной матрицы (только 3 или 4): ");
                    int SizeMatrix = Int32.Parse(Console.ReadLine());
                    if (SizeMatrix > 4 || SizeMatrix < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы ввели некорректное число. Размерность должна быть равна 3 или 4.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    int [,] matrix = new int[SizeMatrix, SizeMatrix];

                    Console.WriteLine("Изначальная матрица:");
                    for (int i = 0; i < SizeMatrix; i++)
                    {
                        for (int j = 0; j < SizeMatrix; j++)
                        {
                            matrix[i,j] = rnd.Next(1, 31);
                            Console.Write(matrix[i,j] + "\t");
                        }
                        Console.WriteLine();
                    }

                    if (SizeMatrix == 3)
                    {
                        for (int i = 0; i < SizeMatrix; i++)
                        {
                            for (int j = 0; j < SizeMatrix; i++)
                            {
                                if (i == 1)
                                {
                                    NumberMatrix = matrix[i, j];
                                    matrix[i, j] = matrix[i--, j];
                                    matrix[i--, j] = NumberMatrix;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < SizeMatrix; i++)
                        {
                            for (int j = 0; j < SizeMatrix; i++)
                            {
                                if (i == 1)
                                {
                                    NumberMatrix = matrix[i, j];
                                    matrix[i, j] = matrix[i--, j];
                                    matrix[i--, j] = NumberMatrix;
                                }
                                if (i == 2)
                                {
                                    NumberMatrix = matrix[i, j];
                                    matrix[i, j] = matrix[i++, j];
                                    matrix[i++,j] = NumberMatrix;
                                }
                            }
                        }
                    }

                    Console.WriteLine("Результирующая матрица:");
                    for (int i = 0; i < SizeMatrix; i++)
                    {
                        for (int j = 0; j < SizeMatrix; i++)
                        {
                            Console.Write(matrix[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                catch (IndexOutOfRangeException iorex)//обработчик исключения IndexOutOfRangeException (Индекс находился вне границ массива)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {iorex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Индекс находился вне границ массива.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                {
                    try
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;//продолжает итерацию внутреннего цикла
                        }
                        else//иначе
                        {
                            if (answer == 0)//если ответ пользователя равен 0
                            {
                                ExitProgram = true;//флаг выхода из программы становится истинным
                                Console.WriteLine("Завершение программы.");//выводится сообщение: Завершение программы.
                            }
                            break;
                        }
                    }
                    catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }

                if (ExitProgram == true)//если выход из программы является истинным
                    break;//завершается внешний цикл
            }
        }
    }
}
