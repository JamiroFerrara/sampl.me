<script lang="ts">
	import FaPlay from 'svelte-icons/fa/FaPlay.svelte';
	import FaPause from 'svelte-icons/fa/FaPause.svelte';

	export let playing: boolean;
	export let onChange: (item: boolean) => {};
	$: onChange(playing);
</script>

<div
	on:click={() => (playing = !playing)}
	class="h-4 m-4 self-center cursor-pointer transition-all hover:scale-110"
>
	{#if playing}
		<FaPause class="absolute" />
	{/if}

	{#if !playing}
		<FaPlay class="absolute" />
	{/if}
</div>
