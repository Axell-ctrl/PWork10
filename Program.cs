//***************************************************************************************************************************************************************************************
//*Практическая работа №10                                                                                                                                                              *
//*Сделал Егоров Н.Н, группа 2-ИСП                                                                                                                                                      *
//*Задание: поменять значения столбцов, размерность нечётная: поменять первый и средний столбец, размерность чётная: средние два столбца поменять с первым и последним соответственно.  *
//***************************************************************************************************************************************************************************************

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
            Console.WriteLine("Здравствуйте!");

            bool ExitProgram = false;//флаг для выхода из цикла повтора программы
            Random rnd = new Random();//создание генератора чисел

            while (true)
            {
                try
                {
                    int NumberMatrix;
                    Console.Write("Введите размерность квадратной матрицы (только 3 или 4): ");
                    int SizeMatrix = Int32.Parse(Console.ReadLine());
                    if (SizeMatrix > 4 || SizeMatrix < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы ввели некорректное число. Размерность должна быть равна 3 или 4.");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    int[,] matrix = new int[SizeMatrix, SizeMatrix];
                    Console.WriteLine("Изначальная матрица:");
                    for (int i = 0; i < SizeMatrix; i++)
                    {
                        for (int j = 0; j < SizeMatrix; j++)
                        {
                            matrix[i, j] = rnd.Next(1, 31);//генерация случайных чисел в диапазоне [1,31)
                            Console.Write(matrix[i, j] + "\t");//вывод матрицы (по индексам + табуляция)
                        }
                        Console.WriteLine();//переход на новую строку
                    }

                    int mid = SizeMatrix / 2;//нахождение середины матрицы
                    int FirstCol = 0;//первая колонка

                    if (SizeMatrix % 2 != 0)//проверка на нечётность матрицы
                    {
                        for (int i = 0; i < SizeMatrix; i++)
                        {
                            //Меняем значения по принципу: запоминаем значение середины матрицы, меняем значения 1-ого (FirstCol = 0) и среднего (mid = 1) столбцов.
                            NumberMatrix = matrix[i, mid];
                            matrix[i, mid] = matrix[i, FirstCol];
                            matrix[i, FirstCol] = NumberMatrix;
                        }
                    }
                    else//иначе (матрица чётная)
                    {

                        for (int i = 0; i < SizeMatrix; i++)
                        {
                            int LeftMid = mid - 1;//левая середина для 4 размерности (1 индекс)
                            int RightMid = mid;//правая середина для 4 размерности (2 индекс)
                            int LastCol = SizeMatrix - 1;//последняя колонка

                            //Меняем значения по принципу: запоминаем значение левой середины матрицы, меняем значения 1-ого (FirstCol = 0) и левого среднего (LeftMid = 1) столбцов.
                            NumberMatrix = matrix[i, LeftMid];
                            matrix[i, LeftMid] = matrix[i, FirstCol];
                            matrix[i, FirstCol] = NumberMatrix;

                            //Меняем значения по принципу: запоминаем значение правой середины матрицы, меняем значения последнего (LastCol = 3) и правого среднего (RightMid = 2) столбцов.
                            NumberMatrix = matrix[i, RightMid];
                            matrix[i, RightMid] = matrix[i, LastCol];
                            matrix[i, LastCol] = NumberMatrix;
                        }
                    }

                    Console.WriteLine("Результирующая матрица:");
                    for (int i = 0; i < SizeMatrix; i++)
                    {
                        for (int j = 0; j < SizeMatrix; j++)
                        {
                            if (SizeMatrix == 3 && (j == 0 || j == 1))//проверка на размер матрицы и столбцы
                            {
                                Console.ForegroundColor = ConsoleColor.Green;//окрашиваем в зелёный
                            }
                            else if (SizeMatrix == 4 && (j == 0 || j == 1))//проверка на первые заменённые столбцы матрицы 4 размерности
                            {
                                Console.ForegroundColor = ConsoleColor.Red;//окрашиваем в красный
                            }
                            else if (SizeMatrix == 4 && (j == 2 || j == 3))//проверка на последние заменённые столбцы матрицы 4 размерности
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;//окрашиваем в тёмно-жёлтый
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;//остальное оставляем в белом цвете
                            }
                            Console.Write(matrix[i, j] + "\t");//вывод результирующей матрицы (по индексам + табуляция)
                        }
                        Console.ForegroundColor = ConsoleColor.White;//возвращаем цвет обратно
                        Console.WriteLine();//переход на новую строку
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
                                Console.WriteLine("Завершение программы. Нажмите для продолжения...");//выводится сообщение: Завершение программы.
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
            Console.ReadKey();//задержка экрана
        }
    }
}
