using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.ExerciseVmDirector;
using FitFalMVC.Domain.Interfaces;

namespace FitFalMVC.Application.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepo;
    private readonly IMapper _mapper;

    public ExerciseService(IExerciseRepository exerciseRepository,IMapper mapper)
    {
        _exerciseRepo = exerciseRepository;
        _mapper = mapper;
    }
    
    
    public ListExerciseForListVm GetAllExercisesForList(int pageSize,int pageNO,string searchString)
    {
        var exercise = _exerciseRepo.GetAllExercises().Where(p=>p.Name.StartsWith(searchString))
            .ProjectTo<FitFalMVC.Application.ViewModels.ExerciseVmDirector.ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();
        var exerciseToShow = exercise.Skip(pageSize * (pageNO - 1)).Take(pageSize).ToList();
        var exerciseList = new ListExerciseForListVm()
        {
            PageSize = pageSize,
            CurrentPage = pageNO,
            SearchString = searchString,
            ExerciseForListVms = exerciseToShow,
            Count = exercise.Count
        };

        return exerciseList;
    }
    
    public ListExerciseForListVm GetAllExercisesForList2()
    {
        var exercise = _exerciseRepo.GetAllExercises()
            .ProjectTo<FitFalMVC.Application.ViewModels.ExerciseVmDirector.ExerciseForListVm>(_mapper.ConfigurationProvider).ToList();
        var exerciseList = new ListExerciseForListVm()
        {
            ExerciseForListVms = exercise
        };

        return exerciseList;
    }

    public ExerciseDetailVm GetExerciseDetail(int id)
    {
        var exercise = _exerciseRepo.GetDetail(id);
        var exerciseVm = _mapper.Map<ExerciseDetailVm>(exercise);
        return exerciseVm;
    }
    
    public ExerciseDetailVm GetExerciseDetailByWorkoutExercise(int id)
    {
        var exercise = _exerciseRepo.GetDetailByWorkoutExercise(id);
        var exerciseVm = _mapper.Map<ExerciseDetailVm>(exercise);
        return exerciseVm;
    }
}